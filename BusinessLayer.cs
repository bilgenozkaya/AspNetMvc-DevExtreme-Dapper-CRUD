using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using NefaMVCWenAppDevEx.Models;

namespace NefaMVCWenAppDevEx.DataModels
{

	public class BusinessLayer : IBusinessLayer<DataModel, int>
	{
		
		SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-BM237L6;Initial Catalog=CARI;Integrated Security=True");
		public bool Delete(int ID)
		{
			try
			{
				using ( SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-BM237L6;Initial Catalog=NEFA;Integrated Security=True") )
				{
					sqlOpen();
					sqlCon.Query<DataModel>("DELETE FROM [dbo].[CARI] WHERE ID = @ID", new { ID = ID });
				}

				return true;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Silme hatası:{1} ID:{0}", ID, ex.Message.ToString()));
			}
			finally
			{
				sqlClose();
			}
		}
		public List<DataModel> GetAll()
		{
			try
			{
				sqlOpen();
				List<DataModel> list =sqlCon.Query<DataModel>(@"SELECT * FROM [dbo].[CARI]").ToList();
				return list;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Listeleme hatası:{0}", ex.Message.ToString()));
			}
			finally
			{
				sqlClose();
			}
		}

		public bool Save(DataModel item)
		{
			try
			{
				sqlOpen();
				sqlCon.Query<DataModel>(@"INSERT INTO [dbo].[CARI]  ([CARIKOD]
           ,[CARIISIM]
           ,[ADRES]
           ,[IL]
           ,[ILCE]
           ,[ULKEKODU]
           ,[TELEFON]
           ,[FAX]
           ,[VERGIDAIRESI]
           ,[VERGINO]
           ,[TCNO]
           ,[POSTAKODU]
           ,[TIP]
           ,[EMAIL]
           ,[WEBADRESI]) VALUES (@CARIKOD,@CARIISIM,@ADRES,@IL,@ILCE,@ULKEKODU,@TELEFON,@FAX,@VERGIDAIRESI,@VERGINO,@TCNO,@POSTAKODU,@TIP,@EMAIL,@WEBADRESI)", item);

				return true;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Ekleme hatası:{1} ID:{0}", item, ex.Message.ToString()));
			}
			finally
			{
				sqlClose();
			}
		}

		public bool Update(DataModel item)
		{
			try
			{
				sqlOpen();
				sqlCon.Query<DataModel>(@"UPDATE [dbo].[CARI] SET [CARIKOD] = @CARIKOD,
      [CARIISIM]     = @CARIISIM,
      [ADRES]        = @ADRES,
      [IL]           = @IL, 
      [ILCE]         = @ILCE,
      [ULKEKODU]     = @ULKEKODU, 
      [TELEFON]      = @TELEFON,
      [FAX]          = @FAX,
      [VERGIDAIRESI] = @VERGIDAIRESI,
      [VERGINO]      = @VERGINO,
      [TCNO]         = @TCNO,
      [POSTAKODU]    = @POSTAKODU,
      [TIP]          = @TIP,
      [EMAIL]        = @EMAIL,
      [WEBADRESI]    = @WEBADRESI WHERE ID = @ID", item);

				return true;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Günclleme hatası:{1} Id:{0}", item, ex.Message.ToString()));
			}
			finally
			{
				sqlClose();
			}
		}
		/// <summary>
		/// Tip Listesi: Alıcı, Satıcı, Toptancı,Kefil,Müstahsil,Diğer
		/// </summary>
		/// <returns></returns>
		public List<Obje> GetTips()
		{
			try
			{
				List<Obje> list = new List<Obje>();

				list.Add(new Obje(){ ID = 1, AD = "Alıcı"  });
				list.Add(new Obje(){ ID = 2, AD = "Satıcı"  });
				list.Add(new Obje(){ ID = 3, AD = "Toptancı"  });
				list.Add(new Obje(){ ID = 4, AD = "Kefil"  });
				list.Add(new Obje(){ ID = 5, AD = "Müstahsil"  });
				list.Add(new Obje(){ ID = 6, AD = "Diğer"  });

				return list;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Listeleme hatası:{0}", ex.Message.ToString()));
			}
		}
		public List<Obje> GetVergiDairesi()
		{
			try
			{
				List<Obje> list = new List<Obje>();

				list.Add(new Obje() { ID = 1, AD = "Antalya VD" });
				list.Add(new Obje() { ID = 2, AD = "Muratpaşa VD" });
				list.Add(new Obje() { ID = 3, AD = "Konyaaltı VD" });
				list.Add(new Obje() { ID = 4, AD = "Kepez VD" });
				list.Add(new Obje() { ID = 5, AD = "Manavgat VD" });
				list.Add(new Obje() { ID = 6, AD = "Alanya VD" });

				return list;
			}
			catch ( Exception ex )
			{

				throw new Exception(string.Format("Listeleme hatası:{0}", ex.Message.ToString()));
			}
		}

		//(ctrl + k +s ) region
		#region Connection Open Close method
		public void sqlOpen()
		{
			if ( sqlCon.State == System.Data.ConnectionState.Closed )
				sqlCon.Open();
		}

		private void sqlClose()
		{
			if ( sqlCon.State == System.Data.ConnectionState.Open )
				sqlCon.Close();
		}
		#endregion

	}
	//objesi
	public class Obje
	{
		public int ID { get; set; }
		public string AD { get; set; }
	}
}
