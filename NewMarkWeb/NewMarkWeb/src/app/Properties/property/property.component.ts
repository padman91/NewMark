import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PropertyService } from '../property.service';
import { Property } from './Property';

@Component({
  selector: 'app-property',
  imports: [CommonModule],
  templateUrl: './property.component.html',
  styleUrl: './property.component.css',
  providers: [PropertyService]
})
export class PropertyComponent {
constructor(private propertyService: PropertyService) { }
properties: Property[] = [];
isExpanded: boolean = false;
ngOnInit() {
  this.propertyService.getProperties().subscribe((data: Property[]) => {
    this.properties = data;
  });
}
toggleExpandCollapse(propertyId: string) {
  const property = this.properties.find(p => p.propertyId === propertyId);
  if (property) {
    property.isExpanded = !property.isExpanded;
  }
}
}
