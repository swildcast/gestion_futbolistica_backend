import { Component } from '@angular/core';
import { Match } from '../../services/partidos.service';

@Component({
  selector: 'app-partido-list',
  templateUrl: './partido-list.component.html',
  styleUrls: ['./partido-list.component.css']
})
export class PartidoListComponent {
  partidos: Match[] = [];

  constructor() {}

  ngOnInit() {
    // Load matches
  }
}
