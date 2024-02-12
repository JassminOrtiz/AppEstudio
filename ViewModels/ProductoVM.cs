using AppPruebaV1.DataAccess;
using AppPruebaV1.DTOs;
using AppPruebaV1.Models;
using AppPruebaV1.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPruebaV1.ViewModels
{
    public partial class ProductoVM : ObservableObject
    {
        private readonly VentaDbContext _context;
        public ProductoVM(VentaDbContext context)
        {
            _context = context;
        }

        private int IdProducto;
        [ObservableProperty]
        private bool loadingEsVisible = false;

        [ObservableProperty]
        private string codigoBarras = string.Empty;

        [ObservableProperty]
        private string nombre = string.Empty;

        [ObservableProperty]
        private CategoriaDTO categoriaSeleccionada;

        [ObservableProperty]
        private int cantidad;

        [ObservableProperty]
        private decimal precio;

        [ObservableProperty]
        ObservableCollection<CategoriaDTO> listaCategoria;

        [ObservableProperty]
        private string tituloPagina;

        public async void Inicio(int idProducto)
        {
            IdProducto = idProducto;



            if (IdProducto == 0)
            {
                TituloPagina = "Agregar producto";
                await ObtenerCategorias();
            }
            else
            {
                TituloPagina = "Editar producto";
                LoadingEsVisible = true;

                await Task.Run(async () =>
                {
                    var encontrado = await _context.Productos.FirstAsync(p => p.IdProducto == IdProducto);
                    CodigoBarras = encontrado.Codigo;
                    Nombre = encontrado.Nombre;
                    Cantidad = encontrado.Cantidad;
                    Precio = encontrado.Precio;

                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        LoadingEsVisible = false;
                        await ObtenerCategorias(encontrado.IdCategoria);
                    });

                });


            }
        }
        

        private async Task ObtenerCategorias(int idCategoria = 0)
        {
            LoadingEsVisible = true;
            await Task.Run(async () =>
            {
                var lstCategoria = await _context.Categorias.ToListAsync();
                var lstTemp = new ObservableCollection<CategoriaDTO>();
                foreach (var item in lstCategoria)
                {
                    lstTemp.Add(new CategoriaDTO
                    {
                        IdCategoria = item.IdCategoria,
                        Nombre = item.Nombre
                    });
                }
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    LoadingEsVisible = false;
                    ListaCategoria = lstTemp;
                    if (idCategoria != 0)
                        CategoriaSeleccionada = ListaCategoria.First(c => c.IdCategoria == idCategoria);
                });
            });
        }


        [RelayCommand]
        private async Task VolverInventario()
        {
            await Shell.Current.Navigation.PopModalAsync();
        }

        [RelayCommand]
        private async Task Guardar()
        {
            LoadingEsVisible = true;
            ProductoResult productoResult = new ProductoResult();

            var enviarProducto = new ProductoDTO
            {
                IdProducto = IdProducto,
                Codigo = CodigoBarras,
                Nombre = Nombre,
                Categoria = CategoriaSeleccionada,
                Cantidad = Cantidad,
                Precio = Precio
            };

            await Task.Run(async () =>
            {

                if (IdProducto == 0)
                {
                    var dbProducto = new Producto
                    {
                        IdProducto = IdProducto,
                        Codigo = CodigoBarras,
                        Nombre = Nombre,
                        IdCategoria = CategoriaSeleccionada.IdCategoria,
                        Cantidad = Cantidad,
                        Precio = Precio
                    };
                    _context.Productos.Add(dbProducto);

                    await _context.SaveChangesAsync();

                    enviarProducto.IdProducto = dbProducto.IdProducto;

                    productoResult = new ProductoResult()
                    {
                        esCrear = true,
                        producto = enviarProducto
                    };

                }
                else
                {
                    var encontrado = await _context.Productos.FirstAsync(p => p.IdProducto == IdProducto);
                    encontrado.IdProducto = IdProducto;
                    encontrado.Codigo = CodigoBarras;
                    encontrado.Nombre = Nombre;
                    encontrado.IdCategoria = CategoriaSeleccionada.IdCategoria;
                    encontrado.Cantidad = Cantidad;
                    encontrado.Precio = Precio;
                    _context.Productos.Update(encontrado);
                    await _context.SaveChangesAsync();

                    productoResult = new ProductoResult()
                    {
                        esCrear = false,
                        producto = enviarProducto
                    };
                }
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    LoadingEsVisible = false;
                    WeakReferenceMessenger.Default.Send(new ProductoMessage(productoResult));
                    await Shell.Current.Navigation.PopModalAsync();
                });
            });

        }

    }
}
