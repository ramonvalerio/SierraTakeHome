interface OrderTableRowProps {
  id: string;
  customerId: string;
  productId: string;
  quantity: number;
  totalCost: number;
}

export default ({
  id,
  customerId,
  productId,
  quantity,
  totalCost
}: OrderTableRowProps) => {
  return (
    <>
      <div className="value">
        <span children={ id } />
      </div>
      <div className="value">
        <span children={ customerId } />
      </div>
      <div className="value">
        <span children={ productId } />
      </div>
      <div className="value">
        <span children={ quantity } />
      </div>
      <div className="value">
        <span children={`$ ${totalCost}`} />
      </div>
    </>
  );
}