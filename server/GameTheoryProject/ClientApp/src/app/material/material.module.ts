import { NgModule } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import {
  MatFormFieldModule,
  MAT_FORM_FIELD_DEFAULT_OPTIONS,
} from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";

@NgModule({
  imports: [MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  exports: [MatCardModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: { appearance: "outline" },
    },
  ],
})
export class MaterialModule {}
