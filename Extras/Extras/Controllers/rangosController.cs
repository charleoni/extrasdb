using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extras.Models;
using Extras.Models.Request;
using Extras.Models.Respuesta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Extras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rangosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    var lst = db.Rangos.Where(x => x.Estado == true).OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(rangosRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Rango oRangos = new Rango
                    {
                        Codigo = oModel.codigo,
                        Rango1 = oModel.rango,
                        Inicio = oModel.inicio,
                        Fin = oModel.fin,
                    };
                    db.Rangos.Add(oRangos);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPut]
        public IActionResult Edit(rangosRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Rango oRango = db.Rangos.Find(oModel.id);
                    oRango.Codigo = oModel.codigo;
                    oRango.Rango1 = oModel.rango;
                    oRango.Inicio = oModel.inicio;
                    oRango.Fin = oModel.fin;
                    db.Entry(oRango).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                //using (LibreriaContext db = new LibreriaContext())
                //{
                //    Editoriale oEditorial = db.Editoriales.Find(Id);
                //    db.Remove(oEditorial);
                //    db.SaveChanges();
                //    oRespuesta.Exito = 1;
                //}

                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    Rango oRangos = db.Rangos.Find(Id);
                    oRangos.Estado = false;
                    db.Entry(oRangos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
