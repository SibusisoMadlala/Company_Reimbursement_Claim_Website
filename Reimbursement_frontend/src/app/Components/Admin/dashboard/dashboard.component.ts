import { Component, inject } from '@angular/core';
import { ReimbursementService } from '../../../Services/reimbursement.service';
import { Claim } from '../../../Shared/Claim';
import { NgFor, NgIf } from '@angular/common';
import { app } from '../../../../../server';
import { Form, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ReimbursementType } from '../../../Shared/ReimbursementType';
import { AnalyticsComponent } from "../analytics/analytics.component";




@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, FormsModule, AnalyticsComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

  ReimbursementService = inject(ReimbursementService);

  declined = false;
  approved = false;
  pending =true;
  analytics = false;
  email! :string
  approve_email!:string
  pending_email!:string
  type!:string
  declinedType!:string
  approvedType!:string

  declinedClaims!: Claim[];
  pendingClaims!: Claim[];
  approvedClaims!: Claim[];
  filterClaims!:Claim[];
  pendingFilterClaims!: Claim[];
  approveFilterClaims!:Claim[];
  reimbursementTypes!: ReimbursementType[]
  approvalId!:Number

  updateForm!: FormGroup
  approveForm!: FormGroup
  editedClaim! :Partial< Claim>

  showModal = false;

  constructor(){
    this.ReimbursementService.GetPendingClaims().subscribe(
      (claims) => {
        
        this.pendingClaims=claims
        this.pendingFilterClaims=claims
      }
    )

    this.ReimbursementService.GetDeclinedClaims().subscribe(
      (claims) => {
        this.declinedClaims=claims;
        this.filterClaims=claims;
      }
    )

    this.ReimbursementService.GetApprovedClaims().subscribe(
      (claims) => {
        
        this.approvedClaims = claims
        this.approveFilterClaims =claims
      }
    )

    this.ReimbursementService.getAllReimbursementTypes().subscribe(
      (types) => {this.reimbursementTypes = types}
    )

    this.approveForm = new FormGroup({
      approvedBy : new FormControl('',Validators.required),
      approvedValue : new FormControl('',Validators.required),
      approveNote: new  FormControl('')

    });
    //this.openPending();
    
  }

  openDeclined(){
    
    this.pending = false;
    this.approved = false;
    this.declined = true;

    const buttonA = document.getElementById('declineButton');
    const buttonB = document.getElementById('pendingButton'); 
    const buttonC = document.getElementById('approveButton'); 
   
   
        buttonA?.classList.toggle('active');
        buttonB?.classList.remove('active');
        buttonC?.classList.remove('active');
  }

  openPending()
  {
    this.approved = false;
    this.declined =false;
    this.pending = true;

    const buttonA = document.getElementById('pendingButton');
    const buttonB = document.getElementById('approveButton'); 
    const buttonC = document.getElementById('declineButton'); 
   
   
        buttonA?.classList.toggle('active');
        buttonB?.classList.remove('active');
        buttonC?.classList.remove('active');

  }

  openApproved()
  {

    const buttonA = document.getElementById('approveButton');
    const buttonB = document.getElementById('pendingButton'); 
    const buttonC = document.getElementById('declineButton'); 
   
   
        buttonA?.classList.toggle('active');
        buttonB?.classList.remove('active');
        buttonC?.classList.remove('active');
        
   

    this.declined = false;
    this.pending = false;
    this.approved =true;

    
  }

  filterByType(){
    this.pendingFilterClaims= this.pendingClaims.filter(a => a.typeName.includes(this.type))
  }

  filterDeclinedByType(){
    this.filterClaims= this.declinedClaims.filter(a => a.typeName.includes(this.declinedType))
  }

  filterApprovedByType(){
    this.approveFilterClaims= this.approvedClaims.filter(a => a.typeName.includes(this.approvedType))
  }

  filterDeclinedByEmail(){
    this.filterClaims=this.declinedClaims.filter(a => a.creator.includes(this.email))
    //console.log(this.email)
  }

  filterPendingByEmail(){
    this.pendingFilterClaims=this.pendingClaims.filter(a => a.creator.includes(this.pending_email))
    //console.log(this.email)
  }

  filterApprovedByEmail(){
    this.approveFilterClaims=this.approvedClaims.filter(a => a.creator.includes(this.approve_email))
    //console.log(this.email)
  }

  claim: any
  declineClaim(id : Number){
    this.ReimbursementService.GetClaimById(id).subscribe(
      (claims) => {

        this.claim = claims
        this.claim.proccessed = true
        //console.log(this.claim)

        
      this.ReimbursementService.updateClaim(id, this.claim).subscribe(
        (claim2) =>{
          console.log(claim2)
          this.ReimbursementService.GetPendingClaims().subscribe(
            (claims) => {
              
              this.pendingClaims=claims
              this.pendingFilterClaims=claims
            }
          )
        }
      );
      }
      
    );
    //this.openDeclined();
    
  }

  claimother: any
  approveClaim(){
    this.ReimbursementService.GetClaimById(this.approvalId).subscribe(
      (claims) => {

        this.claimother = claims
        this.claimother.proccessed = true
        this.claimother.approved = true
        this.claimother.approvedValue = this.approveForm.value.approvedValue
        this.claimother.approvedBy = this.approveForm.value.approvedBy
        this.claimother.approveNote = this.approveForm.value.approveNote
       // console.log(this.claimother)

        
      this.ReimbursementService.updateClaim(this.approvalId, this.claimother).subscribe(
        (claim2) =>{
          console.log(claim2)
          this.ReimbursementService.GetPendingClaims().subscribe(
            (claims) => {
              
              this.pendingClaims=claims
              this.pendingFilterClaims=claims
            }
          )
        }
      );
      }
      
    );

    this.closeModal()
  }

  openModal(id : Number) {
    this.approvalId = id;
    this.showModal = true;
  }

  closeModal() {
    this.showModal = false;
  }

  openAnalytics(){
    const buttonA = document.getElementById('approveButton');
    const buttonB = document.getElementById('pendingButton'); 
    const buttonC = document.getElementById('declineButton'); 
    const buttonD = document.getElementById('analyticsButton'); 
   
        buttonA?.classList.remove('active');
        buttonB?.classList.remove('active');
        buttonC?.classList.remove('active');
        buttonD?.classList.toggle('active');
   

    this.declined = false;
    this.pending = false;
    this.approved =false;
    this.analytics=true;
  }
}
