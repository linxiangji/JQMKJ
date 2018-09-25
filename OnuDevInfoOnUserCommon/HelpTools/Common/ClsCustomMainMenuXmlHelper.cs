using OnuDevInfoOnUserModel.VoClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OnuDevInfoOnUserCommon.HelpTools
{
    [Serializable]
    public class ClsCustomMainMenuXmlHelper
    {
       private static string m_customMainMenuXmlPath = System.IO.Directory.GetCurrentDirectory() + "\\XmlFiles\\ApplicationMainMenu.xml";
        /// <summary>
        /// 查询所有菜单对象xml
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ClsMainMenuVo> GetAllClsMainMenuVoXml()
        {
            ObservableCollection<ClsMainMenuVo> currMainMenuVoList = new ObservableCollection<ClsMainMenuVo>();
            if (File.Exists(m_customMainMenuXmlPath))
            {
                XDocument doc = XDocument.Load(m_customMainMenuXmlPath);
                if (doc != null)
                {
                    IEnumerable<XElement> elementlist = doc.Root.Elements("MenuGroup");
                    foreach (var item in elementlist)
                    {
                        IEnumerable<XElement> informationElem = item.Elements("ClsMainMenuVo");
                        string menuGroup = item.Attribute("name").Value;
                        foreach (var clsMainMenuVo in informationElem)
                        {
                            ClsMainMenuVo currMainMenuVo = new ClsMainMenuVo()
                            {
                                menuGroup = menuGroup,
                                id = clsMainMenuVo.Attribute("id").Value,
                                name = clsMainMenuVo.Attribute("name").Value,
                                image= clsMainMenuVo.Attribute("image").Value,
                                createTime= clsMainMenuVo.Attribute("createTime").Value
                            };
                            currMainMenuVoList.Add(currMainMenuVo);
                        }
                    }
                    return currMainMenuVoList;
                }
            }
            return null;
        }
        /// <summary>
        /// 查询菜单组对象xml
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<ClsMainMenuVo> GetMenuGroupXml()
        {
            ObservableCollection<ClsMainMenuVo> currMainMenuVoList = new ObservableCollection<ClsMainMenuVo>();
            if (File.Exists(m_customMainMenuXmlPath))
            {
                XDocument doc = XDocument.Load(m_customMainMenuXmlPath);
                if (doc != null)
                {
                    IEnumerable<XElement> elementlist = doc.Root.Elements("MenuGroup");
                    foreach (var item in elementlist)
                    {
                        IEnumerable<XElement> informationElem = item.Elements("ClsMainMenuVo");
                        string menuGroup = item.Attribute("name").Value;
                        ClsMainMenuVo currMainMenuVo = new ClsMainMenuVo()
                        {
                            menuGroup = menuGroup,
                        };
                        currMainMenuVoList.Add(currMainMenuVo);
                    }
                    return currMainMenuVoList;
                }
            }
            return null;
        }
        /// <summary>
        /// 修改xml
        /// </summary>
        /// <param name="currMainMenuVo"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool update(ClsMainMenuVo currMainMenuVo, string root)
        {
            bool isXmlUpdateFlag = false;
            XmlDocument currXmlDocument = new XmlDocument();
            currXmlDocument.Load(m_customMainMenuXmlPath);
            XmlNode node = currXmlDocument.SelectSingleNode(root);
            XmlNodeList xnl = node.ChildNodes;
            foreach (var cl in xnl)
            {
                XmlElement xe = cl as XmlElement;
                string name = xe.GetAttribute("name");
                XmlNodeList xml = xe.ChildNodes;
                if (name.Equals(currMainMenuVo.menuGroup))
                {
                    foreach (var student in xml)
                    {
                        XmlElement xel = student as XmlElement;
                        string student_id = xel.GetAttribute("id");
                        if (student_id == currMainMenuVo.id)
                        {
                            xel.SetAttribute("name", currMainMenuVo.name);
                            currXmlDocument.Save(m_customMainMenuXmlPath);
                            isXmlUpdateFlag = true;
                            return isXmlUpdateFlag;
                        }
                    }
                }
            }
            return isXmlUpdateFlag;
        }

        /// <summary>
        /// 查找是否存在此项
        /// </summary>
        /// <param name="stu"></param>
        /// <param name="root"></param>
        private static int lookXml(ClsMainMenuVo currMainMenuVo, string root)
        {
            XmlDocument currXmlDocument = new XmlDocument();
            currXmlDocument.Load(m_customMainMenuXmlPath);
            XmlNode node = currXmlDocument.SelectSingleNode(root);
            XmlNodeList xnl = node.ChildNodes;
            foreach (var cl in xnl)
            {
                XmlElement xe = cl as XmlElement;
                string name = xe.GetAttribute("name");
                XmlNodeList xml = xe.ChildNodes;
                if (name == currMainMenuVo.menuGroup)
                {
                    foreach (var student in xml)
                    {
                        XmlElement xel = student as XmlElement;
                        string student_id = xel.GetAttribute("id");
                        if (student_id == currMainMenuVo.id)
                        {
                            return 1;
                        }
                    }
                    return 0;
                }
            }
            return -1;
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="stu"></param>
        /// <param name="root"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool addXml(ClsMainMenuVo currMainMenuVo, string root)
        {
            bool isAddXmlFlag = false;
            int isExitis = lookXml(currMainMenuVo, root);
            XmlDocument currXmlDocument = new XmlDocument();
            currXmlDocument.Load(m_customMainMenuXmlPath);
            XmlNode node = currXmlDocument.SelectSingleNode(root);
            XmlNodeList xnl = node.ChildNodes;
            switch (isExitis)
            {
                case -1:
                    XmlElement xe1 = currXmlDocument.CreateElement("MenuGroup");
                    xe1.SetAttribute("name", currMainMenuVo.menuGroup);
                    XmlElement xe2 = currXmlDocument.CreateElement("ClsMainMenuVo");
                    xe2.SetAttribute("id", currMainMenuVo.id);
                    xe2.SetAttribute("name", currMainMenuVo.name);
                    xe2.SetAttribute("image", currMainMenuVo.image);
                    xe2.SetAttribute("createTime", currMainMenuVo.createTime);
                    xe1.AppendChild(xe2);
                    node.AppendChild(xe1);
                    currXmlDocument.Save(m_customMainMenuXmlPath);
                    isAddXmlFlag = true;
                    break;
                case 0:
                    foreach (var cl in xnl)
                    {
                        XmlElement xe = cl as XmlElement;
                        string name = xe.GetAttribute("MenuGroup");
                        XmlNodeList xml = xe.ChildNodes;
                        if (name == currMainMenuVo.menuGroup)
                        {
                            XmlElement xel2 = currXmlDocument.CreateElement("ClsMainMenuVo");
                            xel2.SetAttribute("id", currMainMenuVo.id);
                            xel2.SetAttribute("name", currMainMenuVo.name);
                            xel2.SetAttribute("image", currMainMenuVo.image);
                            xel2.SetAttribute("createTime", currMainMenuVo.createTime);
                            xe.AppendChild(xel2);
                            currXmlDocument.Save(m_customMainMenuXmlPath);
                            isAddXmlFlag = true;
                        }
                    }
                    break;
                case 1:
                    return isAddXmlFlag;
            }
            return isAddXmlFlag;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="currMainMenuVo"></param>
        /// <param name="root"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool delXml(ClsMainMenuVo currMainMenuVo, string root)
        {
            bool isDelXmlFlag = false;
            int isExitis = lookXml(currMainMenuVo, root);
            if (isExitis == -1 || isExitis == 0)
            {
                return isDelXmlFlag;
            }
            XmlDocument currXmlDocument = new XmlDocument();
            currXmlDocument.Load(m_customMainMenuXmlPath);
            XmlNode node = currXmlDocument.SelectSingleNode(root);
            XmlNodeList xnl = node.ChildNodes;
            foreach (var cl in xnl)
            {
                XmlElement xe = cl as XmlElement;
                string name = xe.GetAttribute("name");
                XmlNodeList xml = xe.ChildNodes;
                if (name == currMainMenuVo.menuGroup)
                {
                    foreach (var student in xml)
                    {
                        XmlElement xel = student as XmlElement;
                        string student_id = xel.GetAttribute("id");
                        if (student_id == currMainMenuVo.id)
                        {
                            xe.RemoveChild(xel);
                            currXmlDocument.Save(m_customMainMenuXmlPath);
                            isDelXmlFlag = true;
                        }
                    }
                }
            }
            return isDelXmlFlag;
        }
    }
}
