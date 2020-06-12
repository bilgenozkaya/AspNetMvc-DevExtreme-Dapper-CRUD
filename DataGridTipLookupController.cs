using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using NefaMVCWenAppDevEx.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NefaMVCWenAppDevEx.Controllers
{
    public class DataGridTipLookupController : ApiController
    {
		BusinessLayer getModelData;
		// GET: DataGridTipLookup
		[HttpGet]
		public HttpResponseMessage GetTip(DataSourceLoadOptions loadOptions)
		{
			getModelData = new BusinessLayer();
			return Request.CreateResponse(DataSourceLoader.Load(getModelData.GetTips(), loadOptions));
		}
		//[HttpGet]
		//public HttpResponseMessage GetVergiDairesi(DataSourceLoadOptions loadOptions)
		//{
		//	getModelData2 = new BusinessLayer();
		//	return Request.CreateResponse(DataSourceLoader.Load(getModelData2.GetVergiDairesi(), loadOptions));
		//}
	}
}