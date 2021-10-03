import { Component, OnInit,Input } from '@angular/core';
//import { Console } from 'console';
import { Category } from 'src/app/models/category';
import { Plant } from 'src/app/models/plant';
import { PlantService } from 'src/app/services/plant.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-list-of-plants',
  templateUrl: './list-of-plants.component.html',
  styleUrls: ['./list-of-plants.component.scss']
})
export class ListOfPlantsComponent implements OnInit {

  plants!:Plant[];

  constructor(
    private plantService:PlantService,
    public oidcSecurityService: OidcSecurityService ) { }

  ngOnInit(): void {

    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData}) => 
    {
        console.log("List of  IsAuth"+isAuthenticated);
    });

    this.oidcSecurityService.checkAuth().subscribe(({ isAuthenticated, userData, accessToken, idToken, configId }) => {

      console.log("IsAuth "+isAuthenticated);
      console.log("userData "+userData);
      console.log("AccessToken "+accessToken);
      console.log("IdToken "+idToken);
    });

    this.plantService.getFavPlants().subscribe(result => {
      this.plants=result
    },
      error => {

    })

    this.plantService.selectedCategory.subscribe((result) =>{
      if(result){
        this.plantService.getAllPalantInCategory(result.id).subscribe(result=>{
          this.plants=result;
        })
      }
    })   
    this.plantService.selectedPlants.subscribe((result) =>{
      if(result){
        this.plants=result;
        }
    })  
    
  }

}
