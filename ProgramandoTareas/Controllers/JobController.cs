using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.ModelBinding;


using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using ProgramandoTareas.Models;
using System.Threading;

namespace ProgramandoTareas.Controllers
{
    public class JobController : ApiController
    {

        public static string id = "termino como espero";
        
        // GET: api/Job
        public  IEnumerable<string> Get()
        {
            BackgroundJob.Schedule(() => agregarVideo("carlos 933"), DateTime.Now);

            var jobId = BackgroundJob.Schedule(() => agregarVideo("carlos 91"), DateTime.Now.AddMinutes(3));

            id = jobId;


            // tareas es un metodo que se ejecuta en background
            tareas();


            return new string[] { "IdJo " ,id };
        }

       

        public Task tareas()
        {
            
            return Task.Run(() =>
            {
                int i = 0;
                while (i<1000000)
                {
                    Console.WriteLine("Hola ", DateTime.Now);
                    i++;
                }
                Thread.Sleep(20000);
                id = "mal";
            });
        }

        public void agregarVideo(string nombre)
        {
            BackgroundJob.Delete(id);
            var ctx = new MeTubeEntities();
            var video = new Video();
            video.Nombre = nombre;
            video.YoutubeId = "qweqweqwe"+nombre;


          
            var nuevo_obj=ctx.Video.Add(video);
            ctx.SaveChanges();

            nuevo_obj.Nombre = "se puede"+nuevo_obj.Id;
            ctx.SaveChanges();
  
        }

        // GET: api/Job/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Job
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Job/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Job/5
        public void Delete(int id)
        {
        }
    }
}
