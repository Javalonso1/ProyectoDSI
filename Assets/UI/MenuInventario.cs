using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MenuInv_namespace
{
    public class MenuInventario : MonoBehaviour
    {
        const int MAXOBJETOS = 13;
        public List<EspacioInv> list_slots = new List<EspacioInv>();
        public int ultimoSlots = 0;
        VisualElement contenedor_iz;
        VisualElement contenedor_personaje;

        int _cabeza;
        VisualElement Cabeza;
        int _torso;
        VisualElement Torso;
        int _manoDer;
        VisualElement ManoDer;
        int _manoIz;
        VisualElement ManoIz;
        int _piernas;
        VisualElement Piernas;
        int _pies;
        VisualElement Pies;

        void OnEnable()
        {
            VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;
            contenedor_iz = rootve.Q<VisualElement>("BackgroundInventario");
            contenedor_personaje = rootve.Q<VisualElement>("AreaPersonaje");

            Cabeza = rootve.Q<VisualElement>("CabezaImagen");
            _cabeza = -1;
            Torso = rootve.Q<VisualElement>("TorsoImagen");
            _torso = -1;
            ManoIz = rootve.Q<VisualElement>("ManoIzImagen");
            _manoIz = -1;
            ManoDer = rootve.Q<VisualElement>("ManoDerImagen");
            _manoDer = -1;
            Piernas = rootve.Q<VisualElement>("PiernasImagen");
            _piernas = -1;
            Pies = rootve.Q<VisualElement>("PiesImagen");
            _pies = -1;

            InnitInventario();

            contenedor_iz.RegisterCallback<ClickEvent>(SeleccionObj);
            contenedor_personaje.RegisterCallback<ClickEvent>(Desequipar);
        }
        private void InnitInventario()
        {
            for(int i = 0; i < 15;i++)
                AddInvent();

            ultimoSlots = MAXOBJETOS;
            for (int i = 0; i < MAXOBJETOS; i++)
            {
                list_slots[i].Objeto = i;                
            }            
        }        
        private void AddInvent()
        {
            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("PosInventario");
            VisualElement slotPlantilla = plantilla.Instantiate();

            contenedor_iz.Add(slotPlantilla);
            EspacioInv esp = new EspacioInv(slotPlantilla);
            list_slots.Add(esp);
            if(ultimoSlots > 0)
            {
                list_slots[ultimoSlots - 1].SetNext(esp);
            }
            ultimoSlots++;
        }
        private void SeleccionObj(ClickEvent ev)
        {
            VisualElement im = ev.target as VisualElement;

            int i = 0;
            bool found = false;
            while(i < ultimoSlots && !found)
            {
                if (list_slots[i].Imagen == im) found = true;
                else i++;
            }            
            GetComponent<ChangeManager>().ChangeObjeto(list_slots[i]);            
        }
        private void Desequipar(ClickEvent ev)
        {
            VisualElement im = ev.target as VisualElement;

            if(im == Cabeza)
            {
                if(_cabeza != -1)
                {
                    string str = "Obj" + _cabeza;
                    Cabeza.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _cabeza;
                    _cabeza = -1;
                    ultimoSlots++;
                }
            }
            else if (im == Torso)
            {
                if (_torso != -1)
                {
                    string str = "Obj" + _torso;
                    Torso.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _torso;
                    _torso = -1;
                    ultimoSlots++;
                }
            }
            else if (im == ManoIz)
            {
                if (_manoIz != -1)
                {
                    string str = "Obj" + _manoIz;
                    ManoIz.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _manoIz;
                    _manoIz = -1;
                    ultimoSlots++;
                }
            }
            else if (im == ManoDer)
            {
                if (_manoDer != -1)
                {
                    string str = "Obj" + _manoDer;
                    ManoDer.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _manoDer;
                    _manoDer = -1;
                    ultimoSlots++;
                }
            }
            else if(im == Piernas)
            {
                if (_piernas != -1)
                {
                    string str = "Obj" + _piernas;
                    Piernas.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _piernas;
                    _piernas = -1;
                    ultimoSlots++;
                }
            }
            else if (im == Pies)
            {
                if (_pies != -1)
                {
                    string str = "Obj" + _pies;
                    Pies.RemoveFromClassList(str);
                    list_slots[ultimoSlots].Objeto = _pies;
                    _pies = -1;
                    ultimoSlots++;
                }
            }
            GetComponent<StatsManager>().Actualize();
        }

        public int ChangeManDer(int i)
        {
            int x = _manoDer;            
            if (_manoDer != -1)
            {
                string str = "Obj" + _manoDer;
                ManoDer.RemoveFromClassList(str);                
            }
            _manoDer = i;
            if (_manoDer != -1)
            {
                string str = "Obj" + _manoDer;
                ManoDer.AddToClassList(str);
            }
            return x;
        }
        public int ChangeTorso(int i)
        {
            int x = _torso;
            if (_torso != -1)
            {
                string str = "Obj" + _torso;
                Torso.RemoveFromClassList(str);
            }
            _torso = i;
            if (_torso != -1)
            {
                string str = "Obj" + _torso;
                Torso.AddToClassList(str);
            }
            return x;
        }
        public int ChangeBoots(int i)
        {
            int x = _pies;
            if (_pies != -1)
            {
                string str = "Obj" + _pies;
                Pies.RemoveFromClassList(str);
            }
            _pies = i;
            if (_pies != -1)
            {
                string str = "Obj" + _pies;
                Pies.AddToClassList(str);
            }
            return x;
        }
        public int ChangeCasco(int i)
        {
            int x = _cabeza;
            if (_cabeza != -1)
            {
                string str = "Obj" + _cabeza;
                Cabeza.RemoveFromClassList(str);
            }
            _cabeza = i;
            if (_cabeza != -1)
            {
                string str = "Obj" + _cabeza;
                Cabeza.AddToClassList(str);
            }
            return x;
        }
        public int ChangeManIz(int i)
        {
            int x = _manoIz;
            if (_manoIz != -1)
            {
                string str = "Obj" + _manoIz;
                ManoIz.RemoveFromClassList(str);
            }
            _manoIz = i;
            if (_manoIz != -1)
            {
                string str = "Obj" + _manoIz;
                ManoIz.AddToClassList(str);
            }
            return x;
        }
        public int ChangePant(int i)
        {
            int x = _piernas;
            if (_piernas != -1)
            {
                string str = "Obj" + _piernas;
                Piernas.RemoveFromClassList(str);
            }
            _piernas = i;
            if (_piernas != -1)
            {
                string str = "Obj" + _piernas;
                Piernas.AddToClassList(str);
            }
            return x;
        }
        public int getDefensa()
        {
            int x = 0;
            x += getIndividualDefense(_cabeza);
            x += getIndividualDefense(_manoDer);
            x += getIndividualDefense(_manoIz);
            x += getIndividualDefense(_piernas);
            x += getIndividualDefense(_pies);
            x += getIndividualDefense(_torso);
            return x;
        }

        private int getIndividualDefense(int i)
        {
            switch (i)
            {
                case -1:
                    return 0;
                case 0:
                    return 12;
                case 1:
                    return 0;
                case 2:
                    return 0;
                case 3:
                    return 0;
                case 4:
                    return 50;
                case 5:
                    return 35;
                case 6:
                    return 25;
                case 7:
                    return 15;
                case 8:
                    return 15;
                case 9:
                    return 25;
                case 10:
                    return 30;
                case 11:
                    return 45;
                case 12:
                    return 23;
                default: return 0;
            }
        }

        public int getAtaqueMagico()
        {
            int x = 0;
            x += getIndividualAttackMagico(_cabeza);
            x += getIndividualAttackMagico(_manoDer);
            x += getIndividualAttackMagico(_manoIz);
            x += getIndividualAttackMagico(_piernas);
            x += getIndividualAttackMagico(_pies);
            x += getIndividualAttackMagico(_torso);
            return x;
        }

        private int getIndividualAttackMagico(int i)
        {
            switch (i)
            {
                case -1:
                    return 0;
                case 0:
                    return 0;
                case 1:
                    return 55;
                case 2:
                    return 0;
                case 3:
                    return 0;
                case 4:
                    return 0;
                case 5:
                    return 0;
                case 6:
                    return 0;
                case 7:
                    return 0;
                case 8:
                    return 0;
                case 9:
                    return 0;
                case 10:
                    return 0;
                case 11:
                    return 0;
                case 12:
                    return 0;
                default: return 0;
            }
        }

        public int getAtaque()
        {
            int x = 0;
            x += getIndividualAttack(_cabeza);
            x += getIndividualAttack(_manoDer);
            x += getIndividualAttack(_manoIz);
            x += getIndividualAttack(_piernas);
            x += getIndividualAttack(_pies);
            x += getIndividualAttack(_torso);
            return x;
        }

        private int getIndividualAttack(int i)
        {
            switch (i)
            {
                case -1:
                    return 0;
                case 0:
                    return 0;
                case 1:
                    return 51;
                case 2:
                    return 130;
                case 3:
                    return 95;
                case 4:
                    return 0;
                case 5:
                    return 0;
                case 6:
                    return 0;
                case 7:
                    return 0;
                case 8:
                    return 0;
                case 9:
                    return 0;
                case 10:
                    return 0;
                case 11:
                    return 0;
                case 12:
                    return 0;
                default: return 0;
            }
        }

        public int getPeso()
        {
            int x = 0;
            x += getIndividualPeso(_cabeza);
            x += getIndividualPeso(_manoDer);
            x += getIndividualPeso(_manoIz);
            x += getIndividualPeso(_piernas);
            x += getIndividualPeso(_pies);
            x += getIndividualPeso(_torso);
            return x;
        }       

        private int getIndividualPeso(int i)
        {
            switch (i)
            {
                case -1:
                    return 0;                    
                case 0:
                    return 10;                    
                case 1:
                    return 15;                    
                case 2:
                    return 20;                    
                case 3:
                    return 18;                    
                case 4:
                    return 25;                    
                case 5:
                    return 17;
                case 6:
                    return 10;                    
                case 7:
                    return 7;                    
                case 8:
                    return 11;                    
                case 9:
                    return 18;                    
                case 10:
                    return 7;                    
                case 11:
                    return 15;                    
                case 12:
                    return 17;                    
                default: return 0;
            }
        }
    }
}