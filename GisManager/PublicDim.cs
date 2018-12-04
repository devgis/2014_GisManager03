using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesGDB;
using Microsoft.Win32;

namespace GisManager
{
    [Guid("875ec57f-39b1-49fb-a600-7b95d8317545")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("GisManager.PublicDim")]
    public class PublicDim
    {
        public static void ReverseMouseWheel()
        {
            try
            {
                RegistryKey setKey = Registry.CurrentUser.OpenSubKey(@"Software\ESRI\ArcMap\Settings", true);
                if (setKey != null)
                {
                    if (setKey.GetValue("ReverseMouseWheel") == null)
                    {
                        setKey.SetValue("ReverseMouseWheel", 0, RegistryValueKind.DWord);
                    }
                    else if (setKey.GetValue("ReverseMouseWheel").ToString() != "0")
                    {
                        setKey.SetValue("ReverseMouseWheel", 0);
                    }
                }
            }
            catch { }
        }



        /// <summary>                                    //ע��
        /// ͹���㷨
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public static List<TuLine> BruteForceTu(List<IPoint> _list)
        {
            //��¼�����
            List<TuLine> role = new List<TuLine>();

            //����
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (int j = i + 1; j < _list.Count; j++)
                {
                    double a = _list[j].Y - _list[i].Y;
                    double b = _list[i].X - _list[j].X;
                    double c = _list[i].X * _list[j].Y - _list[i].Y * _list[j].X;

                    int count = 0;
                    //�����е���뷽��
                    for (int k = 0; k < _list.Count; k++)
                    {
                        double result = a * _list[k].X + b * _list[k].Y - c;
                        if (result > 0)
                        {
                            count++;
                        }
                        else if (result < 0)
                        {
                            count--;
                        }
                    }
                    //�Ǽ��㣬�����߼�¼����
                    if (Math.Abs(count) == _list.Count - 2)
                    {
                        TuLine line = new TuLine();
                        line.Begin = _list[i];
                        line.End = _list[j];
                        role.Add(line);
                    }
                }

            }
            return role;
        }
    }
}
