import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Player {
  id: number;
  nombre: string;
  posicion: string;
  edad: number;
  idEquipo: number;
}

@Injectable({
  providedIn: 'root'
})
export class JugadoresService {
  private apiUrl = 'http://localhost:5000/api/players';

  constructor(private http: HttpClient) {}

  getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.apiUrl);
  }
}
