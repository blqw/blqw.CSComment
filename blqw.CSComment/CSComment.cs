using System.Xml;

namespace blqw.Reflection
{

    /// <summary> 用于描述一个成员的注释信息
    /// </summary>
    public sealed class CSComment
    {

        public static readonly CSComment Empty = new CSComment();

        private CSComment()
        {
            Param = new CSCommentParamCollection();
            TypeParam = new CSCommentParamCollection();
            Exception = new CSCommentException[0];
        }

        /// <summary> 构造一个 CSComment 对象
        /// </summary>
        /// <param name="node">表示成员注释的节点</param>
        internal CSComment(XmlNode node)
        {
            var summary = node["summary"] ?? node["value"];
            if (summary != null)
            {
                Summary = summary.InnerText.Trim();
            }
            var remarks = node["remarks"];
            if (remarks != null)
            {
                Remarks = remarks.InnerText.Trim(); ;
            }
            var returns = node["returns"];
            if (returns != null)
            {
                Returns = returns.InnerText.Trim(); ;
            }
            var param = node.SelectNodes("param");
            Param = new CSCommentParamCollection();
            foreach (XmlNode item in param)
            {
                var p = new CSCommentParam(item);
                Param[p.Name] = p;
            }

            var typeparam = node.SelectNodes("typeparam");
            TypeParam = new CSCommentParamCollection();
            foreach (XmlNode item in typeparam)
            {
                var p = new CSCommentParam(item);
                TypeParam[p.Name] = p;
            }

            var exception = node.SelectNodes("exception");
            var index = 0;
            Exception = new CSCommentException[exception.Count];
            foreach (XmlNode ex in exception)
            {
                Exception[index] = new CSCommentException(index, ex);
                index++;
            }

        }

        /// <summary> 文档注释中的 summary 或 value 节点, 用于表示注释的主体说明
        /// </summary>
        public string Summary { get; private set; }

        /// <summary> 文档注释中的 remarks 节点, 用于表示备注信息
        /// </summary>
        public string Remarks { get; private set; }

        /// <summary> 文档注释中的 returns 节点, 用于表示返回值信息
        /// </summary>
        public string Returns { get; private set; }

        /// <summary> 文档注释中的 param 节点, 用于表示参数信息
        /// </summary>
        public CSCommentParamCollection Param { get; private set; }

        /// <summary> 文档注释中的 typeparam 节点, 用于表示泛型参数信息
        /// </summary>
        public CSCommentParamCollection TypeParam { get; private set; }

        /// <summary> 文档注释中的 exception 节点
        /// </summary>
        public CSCommentException[] Exception { get; private set; }

        /// <summary> 返回Summary属性或空字符串
        /// </summary>
        public override string ToString()
        {
            return Summary ?? "";
        }
    }





}
