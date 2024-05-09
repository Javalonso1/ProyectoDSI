using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MenuInv_namespace
{
    public class StatsManager : MonoBehaviour
    {
        const int BASE_BARRA = 20;
        const int MAX_LEVEL = 50;

        MenuInventario menInv;

        public int _nivel;
        Label Nivel;
        public int _extra;
        Label Extra;


        public int _vigor;
        Label Vigor;
        public int _inteligencia;
        Label Inteligencia;
        public int _resistencia;
        Label Resistencia;
        public int _fuerza;
        Label Fuerza;
        public int _destreza;
        Label Destreza;
        public int _suerte;
        Label Suerte;

        VisualElement BarraVid;
        VisualElement BarraMan;
        VisualElement BarraStam;

        Label Ataque;
        Label AtaqueMagico;
        Label Defensa;
        Label Peso;
        Label ConseguirObjetos;

        bool sobrepeso = false;

        private void InnitStats()
        {
            _nivel = MAX_LEVEL;          
            _extra = 0;

            _vigor = 16;
            _inteligencia = 4;
            _resistencia = 11;
            _fuerza = 8;
            _destreza = 7;
            _suerte = 4;
        }

        void OnEnable()
        {
            menInv = GetComponent<MenuInventario>();

            VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;

            Nivel = rootve.Q<Label>("NumNivelText");
            Extra = rootve.Q<Label>("NumExtraText");

            Vigor = rootve.Q<Label>("NumVigorText");
            Inteligencia = rootve.Q<Label>("NumIntText");
            Resistencia = rootve.Q<Label>("NumResText");
            Fuerza = rootve.Q<Label>("NumFuerText");
            Destreza = rootve.Q<Label>("NumDesText");
            Suerte = rootve.Q<Label>("NumSuerText");

            BarraVid = rootve.Q("BarraVida");
            BarraMan = rootve.Q("BarraMana");
            BarraStam = rootve.Q("BarraStamina");

            Ataque = rootve.Q<Label>("NumAtText");
            AtaqueMagico = rootve.Q<Label>("NumAtMagText");
            Defensa = rootve.Q<Label>("NumDefText");
            Peso = rootve.Q<Label>("NumPesoText");
            ConseguirObjetos = rootve.Q<Label>("NumObjetsText");


            InnitStats();
            Actualize();
        }

        public void Actualize()
        {
            _nivel = MAX_LEVEL - _extra;
            Nivel.text = _nivel.ToString();
            Extra.text = _extra.ToString();

            Vigor.text = _vigor.ToString();
            Inteligencia.text = _inteligencia.ToString();
            Resistencia.text = _resistencia.ToString();
            Fuerza.text = _fuerza.ToString();
            Destreza.text = _destreza.ToString();
            Suerte.text = _suerte.ToString();



            BarraVid.style.width = BASE_BARRA + (_vigor * 4);
            BarraMan.style.width = BASE_BARRA + (_inteligencia * 4);
            BarraStam.style.width = BASE_BARRA + (_resistencia * 4);

            ActualizeOtherStats();
        }

        public int PesoAguante() { return _resistencia* 3 + _fuerza* 2 + _vigor;}
        public int ProbObjetos() { return _suerte * 2; }
        public int SumaAtaque() { return _fuerza * 4 + _destreza * 2 + _vigor; }
        public int SumaAtaqueMagico() { return _inteligencia * 4 + _destreza; }
        public int SumaDefensa() { return _fuerza * 2 + _resistencia * 2 + _vigor + _destreza; }

        void ActualizeOtherStats()
        {
            string str;

            int at = menInv.getAtaque();
            str = at + "-";
            at += SumaAtaque();
            str += at.ToString();
            Ataque.text = str;

            at = menInv.getAtaqueMagico();
            str = at + "-";
            at += SumaAtaqueMagico();
            str += at.ToString();
            AtaqueMagico.text = str;
            
            str = (menInv.getDefensa() + SumaDefensa()).ToString();
            Defensa.text = str;

            str = menInv.getPeso() + "/" + PesoAguante();
            Peso.text = str;
            if(sobrepeso && menInv.getPeso() <= PesoAguante())
            {
                Peso.RemoveFromClassList("SobrePeso");
                Peso.AddToClassList("NoSobrePeso");
                sobrepeso = false;
            }
            else if (!sobrepeso && menInv.getPeso() > PesoAguante())
            {
                Peso.RemoveFromClassList("NoSobrePeso");
                Peso.AddToClassList("SobrePeso");
                sobrepeso = true;
            }


            str = ProbObjetos().ToString();
            str += "%";
            ConseguirObjetos.text = str;
        }
    }
}