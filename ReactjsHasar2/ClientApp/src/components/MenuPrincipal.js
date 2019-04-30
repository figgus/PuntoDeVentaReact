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
                <p> Ventas: </p>
                <LinkContainer to={'/facturar'} exact>
                    <button >Facturar</button>
                </LinkContainer>
                
                <button >Cierre de caja</button>
                <LinkContainer to={'/total'} exact>
                    <button >Total Vendido</button>
                </LinkContainer>
                
            </div>
        );
    }
}
