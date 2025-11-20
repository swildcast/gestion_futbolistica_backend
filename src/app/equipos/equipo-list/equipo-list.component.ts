import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-equipo-list',
  templateUrl: './equipo-list.component.html',
  styleUrls: ['./equipo-list.component.css']
})
export class EquipoListComponent {
  constructor(private dialog: MatDialog, private snackBar: MatSnackBar) {}

  // Example usage
  openDialog() {
    this.dialog.open(/* dialog component */);
  }

  showSnackBar() {
    this.snackBar.open('Message', 'Close');
  }
}
