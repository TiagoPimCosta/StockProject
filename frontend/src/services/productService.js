const baseUrl = "https://localhost:44381";

export async function getProducts() {
  const response = await fetch(baseUrl+"/api/stock");
  if (response.ok) return response.json();
  throw response;
}

export async function getProduct(id) {
  const response = await fetch(baseUrl+"/api/stock/" + id);
  if (response.ok) return response.json();
  throw response;
}