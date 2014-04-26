using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TestAndroid
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IDataTransferProc
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        Festivalwrapper GetFestivalData();

        [OperationContract]
        Festivalwrapper GetEventData();

        [OperationContract]
        Festivalwrapper GetCountiesData();

        [OperationContract]
        Festivalwrapper GetTownData();

        [OperationContract]
        Festivalwrapper GetFestTypeData();

        [OperationContract]
        Festivalwrapper GetEventTypeData();

        [OperationContract]
        Festivalwrapper GetFesDataByType(int id);

        [OperationContract]
        Festivalwrapper GetTownDataByCounty(int? id);

        [OperationContract]
        Festivalwrapper GetFestListDataByTownId(int id);

        [OperationContract]
        Festivalwrapper GetFestDetailsDataById(int id);


    }

    #region Test WCF
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    #endregion

    #region FestivalVM

    [DataContract]
    public class FestivalVM
    {
        [DataMember]
        public int FestivalId { get; set; }
        [DataMember]
        public string FestivalName { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public virtual CountyVM FestivalCounty { get; set; }
        [DataMember]
        public virtual TownVM FestivalTown { get; set; }
        [DataMember]
        public virtual FestivalTypeVM FType { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public ICollection<EventsVM> Events { get; set; }

    }

    #endregion

    #region EventsVM
    [DataContract]
    public class EventsVM
    {
        [DataMember]
        public int ID { get; set; }
        
        [DataMember]
        public int FestivalID { get; set; }

        [DataMember]
        public string EventsName { get; set; }

        [DataMember]
        public DateTime EventsDate { get; set; }

        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public DateTime EndTime { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public virtual EventTypeVM EType { get; set; }
    }

    #endregion

    #region CountyVM
    [DataContract]
    public class CountyVM
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    #endregion

    #region TownVM
    [DataContract]
    public class TownVM
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int CountyId { get; set; }
    }

    #endregion

    #region FestivalTypeVM
    [DataContract]
    public class FestivalTypeVM
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string FType { get; set; }
    }

    #endregion

    #region EventTypeVM
    [DataContract]
    public class EventTypeVM
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string EType { get; set; }
    }

    #endregion

    #region Festivalwrapper
    [DataContract]
    public class Festivalwrapper
    {
        [DataMember]
        public List<FestivalVM> FestivalList { get; set; }
        [DataMember]
        public List<EventsVM> EventList { get; set; }
        [DataMember]
        public List<CountyVM> CountyList { get; set; }
        [DataMember]
        public List<TownVM> TownList { get; set; }
        [DataMember]
        public List<FestivalTypeVM> FestivalTypeList { get; set; }
        [DataMember]
        public List<EventTypeVM> EventTypeList { get; set; }
    }
    #endregion
}
