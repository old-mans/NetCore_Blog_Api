using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreDBContex.Extend
{
    public interface IJsonHelper
    {
        /// <summary>
        /// 将实体类序列化为JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public string SerializeJSON<T>(T data);

        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public T DeserializeJSON<T>(string json);


        /// <summary>
        /// 日期转换为时间戳（时间戳单位秒）
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public long ConvertToTimeStamp(DateTime time);

        /// DataSet转换为Json  
        /// /// </summary>      
        /// /// <param name="dataSet">DataSet对象</param> 
        /// /// <returns>Json字符串</returns>      
        public string ToJson(DataSet dataSet);

        /// <summary>   
        /// DataSet转换为Json      
        /// /// </summary>      
        /// /// <param name="dataSet">DataSet对象</param>  
        /// /// <returns>Json字符串</returns>      
        public string ToJson(DataSet dataSet, bool isTableName);
        /// <summary>  
        /// Datatable转换为Json      
        /// </summary>      
        /// <param name="table">Datatable对象</param>    
        /// <returns>Json字符串</returns>      
        public string ToJson(DataTable dt);
        /// <summary>   
        /// /// 格式化字符型、日期型、布尔型   
        /// /// </summary>        
        /// /// <param name="str"></param>     
        /// /// <param name="type"></param>    
        /// /// <returns></returns>      
        public string StringFormat(string str, Type type);
        /// <summary>         
        /// /// 过滤特殊字符      
        /// /// </summary>     
        /// /// <param name="s"></param>     
        /// /// <returns></returns>      
        public string String2Json(String s);

    }
}
