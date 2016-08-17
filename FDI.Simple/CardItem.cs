using System;
using System.Collections.Generic;

namespace FDI.Simple
{
    public class CardItem:BaseSimple
    {
        public int ID { get; set; }
        public string CustomerID { get; set; }
        public string CardNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; set; }
        public string CardType { get; set; }
        public string CardStatus { get; set; }
        public string DateIssue { get; set; }
    }

    public class ModelCardItem
    {
        public List<CardItem> LstCardItems { get; set; }
        public List<ThongKeTheItem> LsThongKeTheItems { get; set; }
    }
}