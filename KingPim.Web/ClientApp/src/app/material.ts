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
  MatCardModule,
  MatExpansionModule,
  MatBottomSheetModule,
  MatTooltipModule,
  MatRadioModule
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
    MatCardModule,
    MatExpansionModule,
    MatBottomSheetModule,
    MatTooltipModule,
    MatRadioModule
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
    MatCardModule,
    MatExpansionModule,
    MatBottomSheetModule,
    MatTooltipModule,
    MatRadioModule
  ],
})
export class MaterialModule { }
