import React, { Component } from 'react';
import { Route } from 'react-router';


import { Keyboard } from './components/Keyboard';
import { Cabecera } from './components/Cebecera';
import { MenuPrincipal } from './components/MenuPrincipal';
import { TotalVendido } from './components/TotalVendido';
import { CierreCaja } from './components/CierreCaja';
import { Operadores } from './components/Operadores';
import { Arqueo } from './components/Arqueo';
import { Articulos } from './components/Articulos';
import { AdministradorFolios } from './components/AdministradorFolios';
import { FoliosLocal } from './components/FoliosLocal';
import { Ajustes } from './components/Ajustes';
import { Reimpresion } from './components/Reimpresion';


export default class App extends Component {
  displayName = App.name

  render() {
      return (
          <div>
              <Route path="/menu" component={MenuPrincipal}> </Route>
              <Route path="/facturar" component={Keyboard} />
              <Route path="/total" component={TotalVendido} />
              <Route path="/cierreCaja" component={CierreCaja} />
              <Route path="/Operadores" component={Operadores} />
              <Route path="/Arqueo" component={Arqueo} />

              <Route path="/Articulos" component={Articulos} />

              <Route path="/AdministradorFolios" component={AdministradorFolios} />
              <Route path="/FoliosLocal" component={FoliosLocal} />
              <Route path="/ajustes" component={Ajustes} />
              <Route path="/reimpresion" component={Reimpresion} />
          </div>
    );
  }
}
