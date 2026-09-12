import { Routes } from '@angular/router';
import { Quartos } from './Pages/quartos/quartos';
import { Cadastro } from './Pages/cadastro/cadastro';
import { Reservas } from './Pages/reservas/reservas';

export const routes: Routes = [
  { path: '', redirectTo: 'reservas', pathMatch: 'full' },
  { path: 'quartos', component: Quartos },
  { path: 'cadastro', component: Cadastro },
  { path: 'reservas', component: Reservas },
  { path: '**', redirectTo: 'reservas' }
];