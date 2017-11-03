using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adom.Hhm.Domain.Services
{
    public class AdomMailContent
    {
        public static string AssignServiceMailText =
            @"<html>
	            <head>
	            <body>
		            HOLA, {0}
		            <br/><br/>
		            Se te ha asignado el siguiente servicio, por favor confirma telefónicamente si puedes atenderlo:
		            <br/><br/>
		            <table>
			            <tr>
				            <td><b>Identificación:</b></td>
				            <td>{1}</td>
			            </tr>
			            <tr>
				            <td><b>Nombre paciente:</b></td>
				            <td>{2}</td>
			            </tr>
			            <tr>
				            <td><b>Dirección:</b></td>
				            <td>{3}</td>
			            </tr>
			            <tr>
				            <td><b>Teléfono:</b></td>
				            <td>{4}</td>
			            </tr>
			            <tr>
				            <td><b>Nro. Autorización:</b></td>
				            <td>{5}</td>
			            </tr>
			            <tr>
				            <td><b>Servicio:</b></td>
				            <td>{6}</td>
			            </tr>
			            <tr>
				            <td><b>Fecha inicio*:</b></td>
				            <td>{7}</td>
			            </tr>
			            <tr>
				            <td><b>Fecha finalización**:</b></td>
				            <td>{8}</td>
			            </tr>
			            <tr>
				            <td><b>Frecuencia Terapia:</b></td>
				            <td>{9}</td>
			            </tr>
			            <tr>
				            <td><b>Valor Copago:</b></td>
				            <td>{10}</td>
			            </tr>
			            <tr>
				            <td><b>Frecuencia Copago:</b></td>
				            <td>{11}</td>
			            </tr>	
		            </table>		
		            <br/>
		            <div style='text-align:center'><a href='http://181.49.151.250:51052'>Ingreso a Blue</a></div>					
		            <br/>
		            * La fecha de inicio es una fecha sugerida, ya que la fecha y hora de atención dependerá de lo que se convenga entre terapeuta y paciente.
		            <br/>
		            ** La fecha de finalización es de carácter referencial, ya que todo dependerá de lo que se convenga entre terapeuta y paciente, y de la evolución del mismo.
	            </body>
	            </head>
            </html>";

        public static string CancellationServiceMailText =
                @"<html>
	            <head>
	            <body>
		            HOLA, {0}
		            <br/><br/>
		            Se te ha cancelado el siguiente servicio:
		            <br/><br/>
		            <table>
			            <tr>
				            <td><b>Identificación:</b></td>
				            <td>{1}</td>
			            </tr>
			            <tr>
				            <td><b>Nombre paciente:</b></td>
				            <td>{2}</td>
			            </tr>
			            <tr>
				            <td><b>Dirección:</b></td>
				            <td>{3}</td>
			            </tr>
			            <tr>
				            <td><b>Teléfono:</b></td>
				            <td>{4}</td>
			            </tr>
			            <tr>
				            <td><b>Nro. Autorización:</b></td>
				            <td>{5}</td>
			            </tr>
			            <tr>
				            <td><b>Servicio:</b></td>
				            <td>{6}</td>
			            </tr>
			            <tr>
				            <td><b>Fecha inicio:</b></td>
				            <td>{7}</td>
			            </tr>
			            <tr>
				            <td><b>Fecha finalización:</b></td>
				            <td>{8}</td>
			            </tr>
			            <tr>
				            <td><b>Frecuencia Terapia:</b></td>
				            <td>{9}</td>
			            </tr>
			            <tr>
				            <td><b>Valor Copago:</b></td>
				            <td>{10}</td>
			            </tr>
			            <tr>
				            <td><b>Frecuencia Copago:</b></td>
				            <td>{11}</td>
			            </tr>	
		            </table>		
		            <br/>
		            <div style='text-align:center'><a href='http://181.49.151.250:51052'>Ingreso a Blue</a></div>					
		            <br/>
		            *Para más información, comunícate con la central de operaciones		            
	            </body>
	            </head>
            </html>";

        public static string ProfessionalReasigmentMail =
            @"<html>
	                <head>
	                <body>
		                HOLA, {0}
		                <br/><br/>
		                Se te han retirado visitas en el siguiente servicio:
		                <br/><br/>
		                <table>
			                <tr>
				                <td><b>Identificación:</b></td>
				                <td>{1}</td>
			                </tr>
			                <tr>
				                <td><b>Nombre paciente:</b></td>
				                <td>{2}</td>
			                </tr>
			                <tr>
				                <td><b>Servicio:</b></td>
				                <td>{3}</td>
			                </tr>
			                <tr>
				                <td><b>Cantidad Retirada:</b></td>
				                <td>{4}</td>
			                </tr>
			
		                </table>		
		                <br/>
		                <div style='text-align:center'><a href='http://181.49.151.250:51052'>Ingreso a Blue</a></div>					
		                <br/>
		                * Para más información, comunícate con la central de operaciones
                    </body>
	                </head>
                </html>";
    }
}
