import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ReimbursementService } from '../../../Services/reimbursement.service';
import { Claim } from '../../../Shared/Claim';
import { Currency } from '../../../Shared/Currency';
import { ReimbursementType } from '../../../Shared/ReimbursementType';
import { NgFor , NgIf} from '@angular/common';
import { response } from 'express';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { tick } from '@angular/core/testing';
import { Router } from '@angular/router';
import { error } from 'console';
import { read } from 'fs';

@Component({
  selector: 'app-reimbursement',
  standalone: true,
  imports: [ReactiveFormsModule,NgFor, NgIf, CommonModule],
  templateUrl: './reimbursement.component.html',
  styleUrl: './reimbursement.component.css'
})
export class ReimbursementComponent {

  fb = inject(NonNullableFormBuilder);
  claimForm!: FormGroup;
  updateForm!: FormGroup;
  update = false;
  ReimbursementService= inject(ReimbursementService);
  router = inject(Router)

  currencies! : Currency[]
  types!: ReimbursementType[]
  typesTwo! : ReimbursementType[]
  typeNames !:string[]
  claims!:Claim[]
  showModal = false;
  id!:Number
  type_Name!:string
  type_Id!:Number
  currency_code!:string
  currency_id!: Number

  constructor()  {
    this.claimForm = new FormGroup({
      Date : new FormControl('', Validators.required),
      Reimbursement_Type : new FormControl('', Validators.required),
      Requested_Value : new FormControl('', Validators.required),
      Currency : new FormControl('', Validators.required),
      Image : new FormControl('')

    });

    this.updateForm = new FormGroup({
      date : new FormControl('', Validators.required),
      typeId : new FormControl('', Validators.required),
      typeName: new  FormControl('',Validators.required),
      requestedValue : new FormControl('', Validators.required),
      currencyId : new FormControl('', Validators.required),
      currencyName : new FormControl('', Validators.required),
      image : new FormControl(''),
      proccessed : new FormControl(''),
      approved : new FormControl(''),
      creator : new FormControl(''),
      approveNote: new FormControl(''),
      approvedBy: new FormControl('')

    });

    //this.claims = this.ReimbursementService.getClaimByUser(localStorage.getItem("email")!);

    this.ReimbursementService.getClaimByUser(localStorage.getItem("email")!).subscribe((claims) => {this.claims = claims})
    //this.showModal=true;
    this.ReimbursementService.getAllCurrencies().subscribe((currencies) =>{
      this.currencies = currencies
    })

    this.ReimbursementService.getAllReimbursementTypes().subscribe((types) =>{
      this.types=types;
      
    })

    
  }
  
  

  openModal() {
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }

  fle:any
  createClaim(){
    const imagej: HTMLInputElement | null = document.querySelector("#imagehh")

    if(imagej?.files &&imagej.files[0]){
      const reader = new FileReader()
      reader.onload = () =>{
        this.fle = reader.result
        
        
      }
      reader.readAsDataURL(imagej.files[0])
    }
    const claim : Claim =  {
      
      date : this.claimForm.value.Date ?? '',
      typeId :this.type_Id?? '',
      typeName: this.type_Name ?? '',
      requestedValue : this.claimForm.value.Requested_Value ?? '',
      approvedValue : undefined,
      currencyId : this.currency_id ?? '',
      currencyName : this.currency_code ?? '',
      proccessed : false,
      approved : false,
      creator : localStorage.getItem('email') ?? '',
      image : this.fle ?? '',
      approvedBy: "",
      approveNote:""

    }

    console.log(claim.image)

    if (this.claimForm.valid){
      console.log(claim.image)
      this.ReimbursementService.createNewClaim(claim).subscribe(
        response => {console.log(claim);
        this.ReimbursementService.getClaimByUser(localStorage.getItem("email")!).subscribe((claims) => {this.claims = claims});
        }
      )

      this.showModal = false;
      alert("Claim Created")
    }
    //this.router.navigate(['/reimbursement'])
    
  }

  deleteClaim(id :Number){

    this.ReimbursementService.deleteClaim(id).subscribe(
      response => {console.log("Claim deleted", response);
      this.ReimbursementService.getClaimByUser(localStorage.getItem("email")!).subscribe((claims) => {this.claims = claims});
      alert("Claim deleted")
      }
      
    )

    this.closeModal()
    
  }
  

  editClaim(){
    this.ReimbursementService.updateClaim(this.id,this.updateForm.value).subscribe(
      response => {console.log("Claim  updated", response);
      this.ReimbursementService.getClaimByUser(localStorage.getItem("email")!).subscribe((claims) => {this.claims = claims});
      alert("Claim Edited")
      },
      
    )
    this.closeUpdate();
  }

  loadData(id : Number){
    this.ReimbursementService.GetClaimById(id).subscribe(
      (claims) => {
        const claim = {
          date: claims.date,
          typeId : claims.typeId,
          approvedBy: "",
          approveNote:"",
          typeName: claims.typeName,
          requestedValue : claims.requestedValue,
          currencyId : claims.currencyId,
          currencyName : claims.currencyName,
          image : claims.image,
          proccessed : false,
          approved : false,
          creator : localStorage.getItem('email') ?? ''
           
          
        }
       this.id=id
        this.openForm();
        this.updateForm.patchValue(claim)
      }
    )
  
  }

  onSelect(event: any) {
    const selectedValue = event.target.value; // e.g., "1-TypeName"
    const [id, name] = selectedValue.split('-');
    this.type_Id=id;   // Access the id
    this.type_Name=name; // Access the name
  }

  onSelectCurrency(event: any) {
    const selectedValue = event.target.value; // e.g., "1-TypeName"
    const [id, name] = selectedValue.split('-');
    this.currency_id=id;   // Access the id
    this.currency_code=name; // Access the name
  }

  openForm(){
    this.update = true
  }

  closeUpdate(){
    this.update = false;
  }
}


