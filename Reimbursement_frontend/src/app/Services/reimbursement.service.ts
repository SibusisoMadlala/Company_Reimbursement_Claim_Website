import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Claim } from '../Shared/Claim';
import { Currency } from '../Shared/Currency';
import { ReimbursementType } from '../Shared/ReimbursementType';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class ReimbursementService {


  private reimbursementUrl = "https://localhost:7061/api/claims/GetAllReimbursementTypes";
  private currencyUrl = 'https://localhost:7061/api/claims/GetAllCurrencies';
  private createClaim = 'https://localhost:7061/api/claims/CreateClaim';
  private updateClaimUrl = 'https://localhost:7061/api/claims/UpdateClaim';
  private deleteClaimUrl = 'https://localhost:7061/api/claims/DeleteClaim';
  private allClaimsUrl = 'https://localhost:7061/api/claims/GetAllClaims';
  private claimsByUseridUrl = 'https://localhost:7061/api/claims/GetAllClaimsByUserId'; //should be by email
  private typeNameUrl =" https://localhost:7061/api/claims/Gettypename"
  private claimByIdUrl =" https://localhost:7061/api/claims/GetClaimById"
  private pendingClaimsUrl = " https://localhost:7061/api/claims/GetAllPendingClaims"
  private declinedClaimsUrl = " https://localhost:7061/api/claims/GetAllDeclinedClaims"
  private approvedClaimsUrl = " https://localhost:7061/api/claims/GetAllApprovedClaims"

  constructor(private http: HttpClient) { }

  public getAllReimbursementTypes() : Observable<ReimbursementType[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<ReimbursementType[]> (this.reimbursementUrl, {headers})
  }

  public getAllCurrencies() : Observable<Currency[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<Currency[]>(this.currencyUrl, {headers})
  }

  public createNewClaim (body: Claim) : Observable<Partial<Claim>>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.post<Partial<Claim>>(this.createClaim, body, {headers})
  }

  public updateClaim (id: Number, body : Partial<Claim>) : Observable<Partial<Claim>>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    const url = `${this.updateClaimUrl}/:id?id=${id}`
    return this.http.patch<Partial<Claim>>(url, body, {headers})
  }

  public deleteClaim(id : Number){
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    const newUrl = `${this.deleteClaimUrl}/:id?id=${id}`
    return this.http.delete<void>(newUrl, {headers})
  }

  public getAllClaims() : Observable<Claim[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<Claim[]>(this.allClaimsUrl, {headers})
  }

  public getClaimByUser(id : string) : Observable<Claim[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    const url = `${this.claimsByUseridUrl}/:id?id=${id}`
    return this.http.get<Claim[]>(url, {headers})
  }

  public GetTypeName(id : Number) :Observable<string>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    const url = `${this.typeNameUrl}/:id?id=${id}`
    return this.http.get<string>(url, {headers});
  }

  public GetClaimById(id : Number) : Observable<Claim>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    const url  = `${this.claimByIdUrl}/:id?id=${id}`
    return this.http.get<Claim>(url, {headers})
  }

  public GetPendingClaims() : Observable<Claim[]>{

    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<Claim[]>(this.pendingClaimsUrl, {headers})
  }

  public GetDeclinedClaims() : Observable<Claim[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<Claim[]>(this.declinedClaimsUrl, {headers})
  }

  public GetApprovedClaims() : Observable<Claim[]>{
    const token = localStorage.getItem("token")
    const headers = new HttpHeaders().set('Authorization',`Bearer ${token}`)
    return this.http.get<Claim[]>(this.approvedClaimsUrl, {headers})
  }

}
