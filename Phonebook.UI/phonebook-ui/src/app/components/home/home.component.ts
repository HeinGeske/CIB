import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ModalDismissReasons, NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { EntryModel } from 'src/app/models/entry.model';
import { PhonebookModel } from 'src/app/models/phonebook.model';
import { EntryService } from 'src/app/services/entry/entry.service';
import { PhonebookService } from 'src/app/services/phonebook/phonebook.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  modalReference: NgbModalRef;
  search: string;
  phonebook: PhonebookModel;
  entries: EntryModel[];
  entryForm;

  get name() { return this.entryForm.get('name').value; }
  get number() { return this.entryForm.get('number').value; }
  
  constructor(private phonebookService: PhonebookService, private entryService: EntryService, private modalService: NgbModal, private formBuilder: FormBuilder) {
    this.entryForm = new FormGroup({
      name: new FormControl('', Validators.required),
      number: new FormControl('', Validators.required)
    });
  }

  ngOnInit(): void {
    this.getPhonebook();
  }
  getPhonebook() {
    this.phonebookService.getEntries().subscribe(data => {
      this.phonebook = data.result;
      this.entries = this.phonebook.entries;
    });
  }
  clearEntries() {
    this.entries = this.phonebook.entries;
    this.search = '';
  }
  onSubmitUserDetails(x) {
    if (x.name != "" && x.number != "") {
      this.entryService.addEntry({ Name: x.name, Number: x.number, PhonebookId: this.phonebook.id })
        .subscribe(data => {
          this.getPhonebook();
          this.searchEntries();
          this.modalReference.close();
          this.entryForm.reset();
        });
    }
  }
  searchEntries() {
    if (this.search) {
      this.entryService.searchEntries({ phonebookId: this.phonebook.id, search: this.search }).subscribe(data => {
        this.entries = data.result;
      });
    }
  }
  open(content) {
    this.modalReference = this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
  }
}
