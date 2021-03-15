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
    public class tipoIdentificacionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    var lst = db.TipoIdentificacions.Where(x => x.Estado == true).OrderByDescending(d => d.Id).ToList();
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
        public IActionResult Add(tipoidentificacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    TipoIdentificacion oTi = new TipoIdentificacion
                    {
                        Descripcion = oModel.descripcion,
                    };
                    db.TipoIdentificacions.Add(oTi);
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
        public IActionResult Edit(tipoidentificacionRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (planillaExtrasContext db = new planillaExtrasContext())
                {
                    TipoIdentificacion oTi = db.TipoIdentificacions.Find(oModel.id);
                    oTi.Descripcion = oModel.descripcion;
                    db.Entry(oTi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    TipoIdentificacion oTi = db.TipoIdentificacions.Find(Id);
                    oTi.Estado = false;
                    db.Entry(oTi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
