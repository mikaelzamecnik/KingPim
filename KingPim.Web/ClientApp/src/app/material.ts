import {
  MatButtonModule,
  MatCheckboxModule,
  MatInputModule,
  MatDialogModule,
  MatTableModule,
  MatSelectModule,
  MatListModule,
  MatIconModule,
  MatDividerModule,
  MatBadgeModule,
  MatMenuModule,
  MatCardModule
} from '@angular/material';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    MatInputModule,
    MatTableModule,
    MatSelectModule,
    MatListModule,
    MatIconModule,
    MatDividerModule,
    MatBadgeModule,
    MatMenuModule,
    MatCardModule
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatDialogModule,
    MatInputModule,
    MatTableModule,
    MatSelectModule,
    MatListModule,
    MatIconModule,
    MatDividerModule,
    MatBadgeModule,
    MatMenuModule,
    MatCardModule
  ],
})
export class MaterialModule { }
