export interface Order {
  id: string,
  customerId: string,
  productId: string,
  quantity: number,
  totalCost: number
};

export interface OrderState {
  form: {
    customerId: string,
    productId: string,
    quantity: string
  },
  orders: Order[]
};

export const OrderInitialState: OrderState = {
  form: {
    customerId: '',
    productId: '',
    quantity: ''
  },
  orders: []
};