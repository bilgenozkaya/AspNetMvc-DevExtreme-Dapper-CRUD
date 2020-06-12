using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using NefaMVCWenAppDevEx.DataModels;
using NefaMVCWenAppDevEx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace NefaMVCWenAppDevEx.Controllers
{
    public class ModelDataController : ApiController
	{
		BusinessLayer  getModelData;
		// GET: ModelData
		[HttpGet]
		public HttpResponseMessage Get(DataSourceLoadOptions loadOptions)
		{
			getModelData = new BusinessLayer();
			return Request.CreateResponse(DataSourceLoader.Load(getModelData.GetAll(), loadOptions));
		}
		//Veri Ekleme
		[HttpPost]
		public HttpResponseMessage Post(FormDataCollection form)
		{
			getModelData = new BusinessLayer();
			var values = form.Get("values");
			var newData = new DataModel();
			JsonConvert.PopulateObject(values, newData);

			Validate(newData);
			if ( !ModelState.IsValid )
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join("; ", ModelState.Values
																				.SelectMany(x => x.Errors)
																				.Select(x => x.ErrorMessage)));

			getModelData.Save(newData);

			return Request.CreateResponse(HttpStatusCode.Created);
		}
		//Veri güncelleme
		[HttpPut]
		public HttpResponseMessage Put(FormDataCollection form)
		{
			getModelData = new BusinessLayer();
			var key = Convert.ToInt32(form.Get("key"));
			var values = form.Get("values");
			var newData = getModelData.GetAll().First(e => e.ID == key);

			JsonConvert.PopulateObject(values, newData);

			Validate(newData);
			if ( !ModelState.IsValid )
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join("; ", ModelState.Values
																				.SelectMany(x => x.Errors)
																				.Select(x => x.ErrorMessage)));

			getModelData.Update(newData);

			return Request.CreateResponse(HttpStatusCode.OK);
		}
		//Veri Silme
		[HttpDelete]
		public void Delete(FormDataCollection form)
		{
			getModelData = new BusinessLayer();
			var key = Convert.ToInt32(form.Get("key"));
			var id = getModelData.GetAll().First(e => e.ID == key).ID;

			getModelData.Delete(id);
		}
	}
}