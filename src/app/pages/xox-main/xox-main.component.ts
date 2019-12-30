import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-xox-main',
  moduleId: module.id,
  templateUrl: './xox-main.component.html',
  styleUrls: ['./xox-main.component.css']
})
export class XoxMainComponent implements OnInit {

  public x1y1: string;
  public x2y1: string;
  public x3y1: string;

  public x1y2: string;
  public x2y2: string;
  public x3y2: string;

  public x1y3: string;
  public x2y3: string;
  public x3y3: string;

  constructor() { }

  ngOnInit() {
  }

  public setBlock(value) {
    switch (value) {
      case 'x1y1': {
        this.x1y1 = 'X';
        break;
      }
      case 'x2y1': {
        this.x2y1 = 'X';
        break;
      }
      case 'x3y1': {
        this.x3y1 = 'X';
        break;
      }
      case 'x1y2': {
        this.x1y2 = 'X';
        break;
      }
      case 'x2y2': {
        this.x2y2 = 'X';
        break;
      }
      case 'x3y2': {
        this.x3y2 = 'X';
        break;
      }
      case 'x1y3': {
        this.x1y3 = 'X';
        break;
      }
      case 'x2y3': {
        this.x2y3 = 'X';
        break;
      }
      case 'x3y3': {
        this.x3y3 = 'X';
        break;
      }
      default: {
        break;
      }
    }
  }

}
