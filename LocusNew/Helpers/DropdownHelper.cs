using LocusNew.Persistence;
using LocusNew.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocusNew.Helpers
{
    public class DropdownHelper
    {
        public static List<SelectListItem> GetBedBathList()
        {
            var listBedsBaths = new List<SelectListItem>
            {
                new SelectListItem{Text = "1+", Value = "1", Selected = true},
                new SelectListItem{Text = "2+", Value = "2"},
                new SelectListItem{Text = "3+", Value = "3"},
                new SelectListItem{Text = "4+", Value = "4"},
                new SelectListItem{Text = "5+", Value = "5"},
            };

            return listBedsBaths;
        }

        public static List<SelectListItem> GetFloorsList()
        {
            var listFloors = new List<SelectListItem>
            {
                new SelectListItem{Text = "Svi", Value = "-1", Selected = true},
                new SelectListItem{Text = "Prizemlje", Value = "0"},
                new SelectListItem{Text = "1", Value = "1"},
                new SelectListItem{Text = "2", Value = "2"},
                new SelectListItem{Text = "3", Value = "3"},
                new SelectListItem{Text = "4", Value = "4"},
                new SelectListItem{Text = "5", Value = "5"},
                new SelectListItem{Text = "6+", Value = "6"},
                new SelectListItem{Text = "Suteren", Value = "50"},
                new SelectListItem{Text = "Potkrovlje", Value = "100"},
            };

            return listFloors;
        }

        public static List<SelectListItem> ListingsSortOrder()
        {
            var listSortOrder = new List<SelectListItem>
            {
                new SelectListItem{Text = "Datum objave padajuće", Value = "published_desc", Selected = true},
                new SelectListItem{Text = "Datum objave rastuće", Value = "published_acs"},
                new SelectListItem{Text = "Cijena padajuće", Value = "price_desc"},
                new SelectListItem{Text = "Cijena rastuće", Value = "price_acs"}
            };

            return listSortOrder;
        }

        public static List<SelectListItem> GetJoinary()
        {
            var listJoinary = new List<SelectListItem>
            {
                new SelectListItem{Text = "ALU-drvo", Value = "ALU-drvo", Selected = true},
                new SelectListItem{Text = "Aluminijska", Value = "Aluminijska"},
                new SelectListItem{Text = "Drvena", Value = "Drvena"},
                new SelectListItem{Text = "PVC", Value = "PVC"},
                new SelectListItem{Text = "PVC i drvo", Value = "PVC i drvo"},
            };

            return listJoinary;
        }

        public static List<SelectListItem> GetCentralHeatingEtazno()
        {
            var listCentralHeatingEtazno = new List<SelectListItem>
            {
                new SelectListItem{Text = "Ne", Value = "No", Selected = true},
                new SelectListItem{Text = "Da", Value = "Da"},
                new SelectListItem{Text = "Električno", Value = "Električno"},
                new SelectListItem{Text = "Plinsko", Value = "Plinsko"},
                new SelectListItem{Text = "Lož ulje", Value = "Lož ulje"},
                new SelectListItem{Text = "Čvrsto", Value = "Čvrsto"},
            };

            return listCentralHeatingEtazno;
        }

        public static List<SelectListItem> GetAlternativeHeating()
        {
            var listAlternativeHeating = new List<SelectListItem>
            {
                new SelectListItem{Text = "Ne", Value = "No", Selected = true},
                new SelectListItem{Text = "Električno", Value = "Električno"},
                new SelectListItem{Text = "Plinsko", Value = "Plinsko"},
                new SelectListItem{Text = "Lož ulje", Value = "Lož ulje"},
                new SelectListItem{Text = "Čvrsto", Value = "Čvrsto"},
            };

            return listAlternativeHeating;
        }

        public static List<SelectListItem> GetCanalization()
        {
            var listCanalization = new List<SelectListItem>
            {
                new SelectListItem{Text = "Ne", Value = "false", Selected = true},
                new SelectListItem{Text = "Da", Value = "true"},
                new SelectListItem{Text = "Sept. jama", Value = "Sept. jama"},
            };

            return listCanalization;
        }

        public static List<SelectListItem> GetFinanceType()
        {
            var listFinanceType = new List<SelectListItem>
            {
                new SelectListItem{Text = "Gotovina", Value = "Gotovina", Selected = true},
                new SelectListItem{Text = "Kredit", Value = "Kredit"},
                new SelectListItem{Text = "Gotovina i kredit", Value = "Gotovina i kredit"},
            };

            return listFinanceType;
        }
    }
}