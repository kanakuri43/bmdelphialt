using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommonDefinitions
{
    // データ区分
    public enum State
    {
        Unknown = 0,    // 不明
        Active = 1,     // 有効
        Deleted = 2,    // 削除
        History = 3,    // 修正履歴
        Invalid = 9,    // 無効
    }

    // 税単位区分
    public enum TaxationUnit
    {
        Bill = 1,       // 請求単位
        Slip = 2,       // 伝票単位
        Line = 3,       // 行単位
    }

    public enum OperationType
    {
        Sales = 1,
        Purchase = 2,
        Receipt = 3,
        Payment = 4,
    }

}
