﻿namespace Gestalt.Common.Models
{
    using Newtonsoft.Json;

    public class Queries
    {
        [JsonProperty("id")]
        public long RequestId { get; set; } // "3306877"

        public string message { get; set; } //"Около 3 подъезда дома по улице Бондаренко, 29 огромная лужа. Невозможно пройти ни пожилым людям, ни мамам с колясками и детьми. Необходимо прочистить ливневку и убрать талый снег."

        public long minecology_user_id { get; set; } // "12948142",
        public string minecology_message_id { get; set; } // null,"
        public string visible { get; set; } // "1","
        public string hidden_by_author { get; set; } // "0","
        public string category_id { get; set; } // "25","
        public string address { get; set; } // "Казань, улица Бондаренко, 29","
        public string created_time { get; set; } // "2020-02-21 16:50:45","
        public string organization_id { get; set; } // "23251","
        public string for_house_service { get; set; } // null,"
        public string housing_guid { get; set; } // null,"
        public string personal_account { get; set; } // "","
        public string denied_by_external_contractor { get; set; } // null,"
        public string owner_password { get; set; } // null,"
        public string message_type { get; set; } // null,"
        public string author_type { get; set; } // "1","
        public string lat { get; set; } // "55.821724200000","

        [JsonProperty("long")]
        public string _long { get; set; } // "49.103201700000","
        public string status { get; set; } // "2","
        public string state { get; set; } // null,"
        public string university_id { get; set; } // "0","
        public string avatar { get; set; } // "/uploads/avatars/no-photo.png","
        public string title { get; set; } // "Скопление талых вод около дома","
        public string comment_count { get; set; } // "1","
        public string organization_name { get; set; } // "Администрация Кировского и Московского района г.Казани","
        public string like_count { get; set; } // "0","
        public string organization_user_id { get; set; } // null,"
        public string status_change_time { get; set; } // "2020-02-21 16:58:06","
        public string organization_assigned_time { get; set; } // null,"
        public string rating_count { get; set; } // null,"
        public string average_rating { get; set; } // null,"
        public string gov_answer { get; set; } // "Ваше обращение опубликовано","
        public string territory { get; set; } // "Казань","
        public string control_date { get; set; } // "2020-03-02 16:58:06","
        public string closed_by_user { get; set; } // "0","
        public string region { get; set; } // "16","
        public string level { get; set; } // "3","
        public string has_akm_notify { get; set; } // "0","
        public string akm_notify_count { get; set; } // "0","
        public string akm_notify_time { get; set; } // null,"
        public string changed_time { get; set; } // "2020-02-21 17:18:48","
        public string visible_user_info { get; set; } // "0","
        public string client_type { get; set; } // "android","
        public string processing_system { get; set; } // "1","
        public string is_esia_authorized { get; set; } // "0","

        public PhotoModel[] photos { get; set; }
        
        // public string[] photos { get; set; } //{
        // 	"photo{ get; set; } // "3306877-1-0.7053819239616512.jpg",
        // 	"small_photo{ get; set; } // "small-3306877-1-0.7053819239616512.jpg",
        // 	"medium_photo{ get; set; } // "medium-3306877-1-0.7053819239616512.jpg",
        // 	"original_photo{ get; set; } // "original-3306877-1-0.7053819239616512.jpg"
        // };
        public string small_photo { get; set; } // "small-3306877-1-0.7053819239616512.jpg","
        public string medium_photo { get; set; } // "medium-3306877-1-0.7053819239616512.jpg","
        public string category_name { get; set; } // "Благоустройство территории","
        public string author { get; set; } // "Ольга ","
        public string status_message { get; set; } // "В работе","
        public string level_name { get; set; } // "автоопределение","
        public bool? owner { get; set; } // false,"
        public bool? favorite { get; set; } // false,"
        public string create_date { get; set; } // "21.02.2020","
        public string create_time { get; set; } // "16:50","
        public string change_date { get; set; } // "21.02.2020","
        public string change_time { get; set; } // "16:58","
        public string original_photo { get; set; } // ""
    }
}