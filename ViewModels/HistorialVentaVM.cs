using AppPruebaV1.DataAccess;
using AppPruebaV1.DTOs;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPruebaV1.ViewModels
{
    public partial class HistorialVentaVM : ObservableObject
    {
        private readonly VentaDbContext _context;
        [ObservableProperty]
        ObservableCollection<VentaDTO> listaVenta = new ObservableCollection<VentaDTO>();

        public HistorialVentaVM(VentaDbContext context)
        {
            _context = context;
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await ObtenerVentas();
            });
        }

        public async Task ObtenerVentas()
        {

            var lista = await _context.Ventas.OrderByDescending(v => v.IdVenta).ToListAsync();

            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaVenta.Add(new VentaDTO
                    {
                        Cliente = item.Cliente,
                        NumeroVenta = item.NumeroVenta,
                        Total = item.Total,
                        PagoCon = item.PagoCon,
                        Cambio = item.Cambio,
                        FechaRegistro = item.FechaRegistro.ToString("dd/MM/yyyy")
                    });
                }
            }


        }
    }
}
