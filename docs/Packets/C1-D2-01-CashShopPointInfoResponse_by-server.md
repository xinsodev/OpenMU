# C1 D2 01 - CashShopPointInfoResponse (by server)

## Is sent when

Get cash shop points information.

## Causes the following actions on the client side

Got cash shop points information.

## Structure

| Index | Length | Data Type | Value | Description |
|-------|--------|-----------|-------|-------------|
| 0 | 1 |   Byte   | 0xC1  | [Packet type](PacketTypes.md) |
| 1 | 1 |    Byte   |   45   | Packet header - length of the packet |
| 2 | 1 |    Byte   | 0xD2  | Packet header - packet type identifier |
| 3 | 1 |    Byte   | 0x01  | Packet header - sub packet type identifier |
| 4 | 1 | Byte |  | ViewType |
| 5 | 8 | Double |  | TotalCash |
| 13 | 8 | Double |  | CashCredit |
| 21 | 8 | Double |  | CashPrepaid |
| 29 | 8 | Double |  | TotalPoint |
| 37 | 8 | Double |  | TotalMileage |