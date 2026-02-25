# C1 D2 02 - CashShopOpenStateResponse (by server)

## Is sent when

Open/close cash shop.

## Causes the following actions on the client side

Cash shop is opened/closed.

## Structure

| Index | Length | Data Type | Value | Description |
|-------|--------|-----------|-------|-------------|
| 0 | 1 |   Byte   | 0xC1  | [Packet type](PacketTypes.md) |
| 1 | 1 |    Byte   |   5   | Packet header - length of the packet |
| 2 | 1 |    Byte   | 0xD2  | Packet header - packet type identifier |
| 3 | 1 |    Byte   | 0x02  | Packet header - sub packet type identifier |
| 4 | 1 | Boolean |  | IsOpened |