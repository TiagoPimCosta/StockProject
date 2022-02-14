let products = [
  
  {

    "id": 1,

    "name": "Coat",

    "color": "Red",

    "price": 120,

    "brand": "Adidas",

    "description": "Coat description",

    "quantity": 75

  },
  {

    "id": 2,

    "name": "Coat2",

    "color": "Red",

    "price": 150,

    "brand": "Nike",

    "description": "Coat2 description",

    "quantity": 60

  }
];

export function getProducts() {
  return products;
}

export function getProductDetails(id){
  let product = products.find((p) => p.id.toString() === id.toString());
  return product;
}