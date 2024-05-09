using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

namespace MenuInv_namespace
{
    public class EspacioInv
    {
        VisualElement imagen;

        EspacioInv _next = null;

        private int _objeto;
        public int Objeto
        {
            get { return _objeto; }
            set 
            {
                if(_objeto != -1)
                {
                    string str = "Obj" + _objeto;
                    imagen.RemoveFromClassList(str);
                }                
                _objeto = value;
                if (_objeto != -1)
                {
                    string str = "Obj" + _objeto;
                    imagen.AddToClassList(str);
                }
                else
                {
                    if(_next != null && _next.Objeto != -1)
                    {
                        _objeto = _next.Objeto;
                        string str = "Obj" + _objeto;
                        imagen.AddToClassList(str);
                        _next.Objeto = -1;
                    }
                }
            }
        }
        
        public EspacioInv(VisualElement _base)
        {
            _objeto = -1;
            imagen = _base.Q("Imagen");
        }
        public void SetNext(EspacioInv inv)
        {
            _next = inv;
        }
        public VisualElement Imagen
        {
            get { return imagen; }
            set { imagen = value; }
        }
    }
}