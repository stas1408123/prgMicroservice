import { HttpClient,HttpHeaders  } from '@angular/common/http';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService implements OnInit{
  
  private url = 'https://localhost:5002/api/Category/';

  constructor(private http:HttpClient,
    public oidcSecurityServices:OidcSecurityService) { }

  private httpOptions = {
    headers: new HttpHeaders({
      Authorization: 'Bearer ' + this.oidcSecurityServices.getAccessToken(),
    }),
  };

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

  getAllCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.url}GetAllCategories`,this.httpOptions);
  }

  addNewCategory(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.url}`, category,this.httpOptions);
  }

  updateCategory(category: Category): Observable<Category> {
    return this.http.put<Category>(`${this.url}`, category,this.httpOptions);
  }

  deleteCategory(categoryId: number): Observable<void> {
    return this.http.delete<void>(`${this.url}/${categoryId}`,this.httpOptions);
  }

  
}
