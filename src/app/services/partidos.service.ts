import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Match {
  id: number;
  fecha: string;
  idEquipoLocal: number;
  idEquipoVisitante: number;
  golesLocal: number;
  golesVisitante: number;
}

@Injectable({
  providedIn: 'root'
})
export class PartidosService {
  private apiUrl = 'http://localhost:5000/api/matches';

  constructor(private http: HttpClient) {}

  getMatches(): Observable<Match[]> {
    return this.http.get<Match[]>(this.apiUrl);
  }

  getPartido(id: number): Observable<Match> {
    return this.http.get<Match>(`${this.apiUrl}/${id}`);
  }
}
