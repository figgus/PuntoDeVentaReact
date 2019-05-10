import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { LinkContainer } from 'react-router-bootstrap';

export class MenuPrincipal extends Component {
    displayName = MenuPrincipal.name

    constructor() {
        super();
        
    }

    
    render() {
        return (
            <div>
                <p> <h1> Ventas: </h1> </p>
                <hr/>
                <LinkContainer to={'/facturar'} exact>
                    <button >Facturar</button>
                </LinkContainer>
                <LinkContainer to={'/cierreCaja'} exact>
                    <button >Cierre de caja</button>
                </LinkContainer>

                <LinkContainer to={'/Operadores'} exact>
                    <button >Operadores</button>
                </LinkContainer>

                <LinkContainer to={'/Arqueo'} exact>
                    <button >Arqueo</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Total Vendido</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Informe X - Z</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >IVA Ventas</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Cambio de Operador</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Listados e Informes</button>
                </LinkContainer>
                <p></p>


                <p><h1>Stock y Compras</h1></p>
                <hr/>
                <LinkContainer to={'/Articulos'} exact>
                    <button >Articulos</button>
                </LinkContainer>
                <LinkContainer to={'/cierreCaja'} exact>
                    <button >Proveedores y gastos</button>
                </LinkContainer>

                <LinkContainer to={'/Operadores'} exact>
                    <button >Conceptos</button>
                </LinkContainer>

                <LinkContainer to={'/Arqueo'} exact>
                    <button >Movimientos</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Listados de Stock</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Cambio de precios</button>
                </LinkContainer>

                <LinkContainer to={'/total'} exact>
                    <button >Impresion de estiquetas</button>
                </LinkContainer>

            </div>
        );
    }
}
