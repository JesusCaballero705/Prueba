﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UTTT.Ejemplo.Persona;

namespace UTTT.Ejemplo.Persona.Control
{
     public class CTRLValidaInyection
    {
    public bool htmlInyectionValida(String _informacion, ref string _mensaje, string _etiquetaReferente,
        ref System.Web.UI.WebControls.TextBox _control)
        {
            Regex tagRegex = new Regex(@"<.*?>|&.*?;"); 
            //@"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>"
            bool respuesta = tagRegex.IsMatch(_informacion);
            if (respuesta)
            {
                _mensaje = "Caracteres no permitidos en " + _etiquetaReferente.Replace(":", "");
                _control.Focus();
            }
            return respuesta;
        }
        public bool sqlInyectionValida(String _informacion, ref string _mensaje, string _etiqutaReferente,
            ref System.Web.UI.WebControls.TextBox _control)
        {
            Regex tagRegex = new Regex(@"('(''|[^'])*')|(\b(ALTER|alter|Alter|CREATE|
            vreate|Create|DELETE|delete|Delete|DROP|drop|Drop|EXEC(UTE){0,1}|exec(ute){0,1}|
            Exec(ute){0,1}|INSERT( +INTO){0,1}|insert( +into){0,1}|Insert( +into){0,1}|MERGE|
            merge|Merge|SELECT|select|Select|UPDATE|update|Update|UNION( +ALL){0,1}|union( +all){0,1}
            |Union( +all){0,1})\b)");
            bool respuesta = tagRegex.IsMatch(_informacion);
            if (respuesta)
            {
                _mensaje = "Sintaxis no permitida en " + _etiqutaReferente.Replace(":", "");
                _control.Focus();
            }
            return respuesta;
        }
    }
}
