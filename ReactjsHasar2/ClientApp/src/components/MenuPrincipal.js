import React, { Component } from 'react';
import { LinkContainer } from 'react-router-bootstrap';

export class MenuPrincipal extends Component {
    displayName = MenuPrincipal.name

    constructor() {
        super();
        
    }

    
    render() {
        return (
            <div>
                <h1> Ventas: </h1>
                <hr/>
                <LinkContainer to={'/facturar'} exact>
                    <button className="btn btn-primary">Facturar</button>
                </LinkContainer>
                
                <LinkContainer to={'/devoluciones'} exact>
                    <button className="btn btn-primary"> Devoluciones </button>
                </LinkContainer>
                <LinkContainer to={'/cierreCaja'} exact>
                    <button className="btn btn-primary">Cierre de caja</button>
                </LinkContainer>

                <LinkContainer to={'/Operadores'} exact>
                    <button className="btn btn-primary">Operadores</button>
                </LinkContainer>

                <LinkContainer to={'/Arqueo'} exact>
                    <button className="btn btn-primary">Arqueo</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Total Vendido</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary" >Informe X - Z</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">IVA Ventas</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Cambio de Operador</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Listados e Informes</button>
                </LinkContainer>
                <p></p>


                <h1>Stock y Compras</h1>
                <hr/>
                <LinkContainer to={'/Articulos'} exact>
                    <button className="btn btn-primary">Articulos</button>
                </LinkContainer>
                <LinkContainer to={'/cierreCaja'} exact>
                    <button className="btn btn-primary">Proveedores y gastos</button>
                </LinkContainer>

                <LinkContainer to={'/Operadores'} exact>
                    <button className="btn btn-primary">Conceptos</button>
                </LinkContainer>

                <LinkContainer to={'/Arqueo'} exact>
                    <button className="btn btn-primary">Movimientos</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Listados de Stock</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Cambio de precios</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button className="btn btn-primary">Impresion de estiquetas</button>
                </LinkContainer>

                <h1>Administracion</h1>
                <hr />
                <LinkContainer to={'/AdministradorFolios'} exact>
                    <button className="btn btn-primary">Servicio Folios </button>
                </LinkContainer>
                <LinkContainer to={'/FoliosLocal'} exact>
                    <button className="btn btn-primary"> Folios Locales </button>
                </LinkContainer>
                <LinkContainer to={'/reimpresion'} exact>
                    <button className="btn btn-primary"> Reimpresion de facturas </button>
                </LinkContainer>
                <LinkContainer to={'/ajustes'} exact>
                    <button className="btn btn-primary"> Ajustes </button>
                </LinkContainer>

            </div>
        );
    }
}
