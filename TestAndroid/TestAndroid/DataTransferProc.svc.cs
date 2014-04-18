using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestAndroid
{
    public class DataTransferProc : IDataTransferProc
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public Festivalwrapper GetFestivalData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                /*returnType.FestivalList = (from fest in c.Festivals
                                           select new FestivalVM()).ToList();*/

                returnType.FestivalList = (from f in c.Festivals
                                        select new FestivalVM()
                                        {
                                            FestivalId = f.FestivalId,
                                            FestivalName = f.FestivalName,
                                            StartDate = f.StartDate,
                                            EndDate = f.EndDate,
                                            Description = f.Description,
                                        }).ToList();
            }
            return returnType;
        }

        public Festivalwrapper GetEventData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                /*returnType.EventList = (from eve in c.Events
                                        select new EventsVM()).ToList();*/

                returnType.EventList = (from e in c.Events
                            select new EventsVM()
                            {
                                ID = e.ID,
                                FestivalID = e.FestivalID,
                                EventsName = e.EventsName,
                                EventsDate = e.EventsDate,
                                StartTime = e.StartTime,
                                EndTime = e.EndTime
                            }).ToList();

            }
            return returnType;
        }

        public Festivalwrapper GetCountiesData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                returnType.CountyList = (from county in c.Counties
                                         select new CountyVM()
                                         {
                                             ID = county.ID,
                                             Name = county.Name
                                         }).ToList();
            }
            return returnType;
        }

        public Festivalwrapper GetTownData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                returnType.TownList = (from town in c.Towns
                                       select new TownVM()
                                       {
                                           ID = town.ID,
                                           Name = town.Name
                                       }).ToList();
            }
            return returnType;
        }

        public Festivalwrapper GetFestTypeData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                returnType.FestivalTypeList = (from festivaltype in c.FestivalTypes
                                               select new FestivalTypeVM()
                                               {
                                                   ID = festivaltype.ID,
                                                   FType = festivaltype.FType
                                               }).ToList();
            }
            return returnType;
        }

        public Festivalwrapper GetEventTypeData()
        {
            Festivalwrapper returnType = new Festivalwrapper();
            using (azureDBDataContext c = new azureDBDataContext())
            {
                returnType.EventTypeList = (from eventtype in c.EventTypes
                                            select new EventTypeVM()
                                            {
                                                ID = eventtype.ID,
                                                EType = eventtype.EType
                                            }).ToList();
            }
            return returnType;
        }
    }
}
