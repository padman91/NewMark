export class Property {
    propertyId: string = '';
    propertyName: string='';
    features = [];
    highlights = [];
    transportation:Transportation[] = [];
    spaces:Space[] = [];
    isExpanded: boolean = false;
}

// filepath: models/Transportation.js
class Transportation {
    type: string = '';
    line: string = '';
    distance: string = '';
}

// filepath: models/Space.js
class Space {
    spaceId: string =  '' ;
    spaceName:string = '';
    rentRoll:RentRoll[] = [];
}

// filepath: models/RentRoll.js
class RentRoll {
    month:string = '';
    rent:string = '';
}