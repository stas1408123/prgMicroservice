import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-new-category',
  templateUrl: './add-new-category.component.html',
  styleUrls: ['./add-new-category.component.scss']
})
export class AddNewCategoryComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AddNewCategoryComponent>,
    private categoryService: CategoryService,
    private snackBar: MatSnackBar
  ) { }

  category: Category = {

    id: 0,
    name: "",
    description: ""

  }

  ngOnInit(): void {
  }

  add() {
    this.categoryService.addNewCategory(this.category).subscribe(result => {
      if (this.category) {
        this.snackBar.open('The category was successfully added', '', {
          duration: 2000,
        })
      }
    }, error => {

    });

    this.dialogRef.close();
  }

  cancel() {
    this.dialogRef.close();
  }

}
