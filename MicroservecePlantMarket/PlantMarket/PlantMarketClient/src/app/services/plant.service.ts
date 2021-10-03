import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Observable, Subject } from 'rxjs';
import { Category } from '../models/category';
import { Plant } from '../models/plant';

@Injectable({
  providedIn: 'root'
})
export class PlantService implements OnInit{

  private url ='https://localhost:5002/api/Plant/';
  //private httpOptions?: HttpHeaders="";

  private httpOptions = {
  headers: new HttpHeaders({
    Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
  }),
};

  public selectedCategory:Subject<Category> =new Subject<Category>()

  public selectedPlants:Subject<Plant[]> =new Subject<Plant[]>() 
  
  constructor(public http: HttpClient,
    public oidcSecurityServices:OidcSecurityService) { }

  ngOnInit() {
    this.oidcSecurityServices.checkAuth().subscribe((auth) => {
      /*...*/
      console.log("Is Auth"+auth);

      this.httpOptions = {
        headers: new HttpHeaders({
          Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
      }),
     };
    });
  }

  getAllPlants(): Observable<Plant[]>{

    // const token = this.oidcSecurityServices.getAccessToken();

    // console.log(token);

    return this.http.get<Plant[]>(`${this.url}GetAllProducts`,this.httpOptions);
  }

  getplantById(id :number):Observable<Plant>{
    return this.http.get<Plant>(`${this.url}GetPlant/?id=${id}`,this.httpOptions)
  }

  search(name : string):Observable<Plant[]>{
    return this.http.get<Plant[]>(`${this.url}Search/?name=${name}`,this.httpOptions)
  }

  addPlant(newPlant :Plant) : Observable<Plant>{
    return this.http.post<Plant>(`${this.url}AddPlant`,newPlant,this.httpOptions);
  }

  deletePlantById(id:number) :Observable<boolean>{
    return this.http.delete<boolean>(`${this.url}DeletePlant/${id}`,this.httpOptions)
  }


  updatePlant(UpdatedPlant: Plant): Observable<Plant>{
    return this.http.put<Plant>(`${this.url}`,UpdatedPlant,this.httpOptions);
  }

  getFavPlants(): Observable<Plant[]>{

    /*const token = this.oidcSecurityServices.getAccessToken();

    console.log(token);

    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + token,
    }),
   };*/


    return this.http.get<Plant[]>(`${this.url}GetFavPlants`,this.httpOptions);

  }

  getAllPalantInCategory(categoryId :number) : Observable<Plant[]>{
    return this.http.get<Plant[]>(`${this.url}GetAllPalantInCategory/?categoryId=${categoryId}`,this.httpOptions);
  }


}
