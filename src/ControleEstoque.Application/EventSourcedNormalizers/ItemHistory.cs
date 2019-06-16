﻿using ControleEstoque.Domain.Core.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque.Application.EventSourcedNormalizers
{
    public class ItemHistory
    {
        public static IList<ItemHistoryData> HistoryData { get; set; }

        public static IList<ItemHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<ItemHistoryData>();
            ItemHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<ItemHistoryData>();
            var last = new ItemHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ItemHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    BirthDate = string.IsNullOrWhiteSpace(change.BirthDate) || change.BirthDate == last.BirthDate
                        ? ""
                        : change.BirthDate.Substring(0, 10),
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ItemHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new ItemHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "ItemRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.Name = values["Name"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ItemUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.BirthDate = values["BirthDate"];
                        slot.Email = values["Email"];
                        slot.Name = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "ItemRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
