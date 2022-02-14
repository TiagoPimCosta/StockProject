const baseUrl = "https://localhost:5001";

//Add Product

//Get Product
// Drop down list

//Get Product Details

export async function getProductDetails(id) {
  const response = await fetch(baseUrl+"/api/stock/" + id);
  if (response.ok) return response.json();
  throw response;
}

//Get All Products

export async function getProducts() {
  const response = await fetch(baseUrl+"/api/stock");
  if (response.ok) return response.json();
  throw response;
}

//StockIn

//StockOut
