import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { PlantService } from 'src/app/services/plant.service';
import { CategoryService } from 'src/app/services/category.service';
import { Category } from 'src/app/models/category';
import { Plant } from 'src/app/models/plant';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-add-new-plant',
  templateUrl: './add-new-plant.component.html',
  styleUrls: ['./add-new-plant.component.scss']
})
export class AddNewPlantComponent implements OnInit {

  plant : Plant  = {

    id: 0,

    name: "",

    price: 0,

    shortDescription: "",

    longDescription: "",
    
    pictureLink :"" ,

    isFavourite: true,

    isAvailable: true,

    categoryId: 0
}


  categories:Category[] = [];

  constructor(
    public dialogRef: MatDialogRef<AddNewPlantComponent>,
    private categoryService:CategoryService,
    private plantService:PlantService,
    private snackBar:MatSnackBar
  ) { }

  ngOnInit(): void {
    this.categoryService.getAllCategories().subscribe(result =>{
      if(result){
        this.categories=result;
      }
    },
      error =>{

      }
    )
  }

  add(){
    this.plantService.addPlant(this.plant).subscribe(result =>{
      if(this.plant)
      {
        this.snackBar.open('The plant was successfully added', '', {
          duration: 2000,
        })
      }
    }, error=>{

    });

    this.dialogRef.close();
  }

  cancel(){
    this.dialogRef.close();
  }

}
