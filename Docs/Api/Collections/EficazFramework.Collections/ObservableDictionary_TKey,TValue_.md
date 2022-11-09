#### [EficazFramework.Collections](EficazFrameworkCollections.md 'EficazFramework Collections')
### [EficazFramework.Collections](EficazFrameworkCollections.md#EficazFramework.Collections 'EficazFramework.Collections')

## ObservableDictionary<TKey,TValue> Class

```csharp
public class ObservableDictionary<TKey,TValue> :
System.Collections.Generic.IDictionary<TKey, TValue>,
System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>,
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>,
System.Collections.IEnumerable,
System.ComponentModel.INotifyPropertyChanged,
System.Collections.Specialized.INotifyCollectionChanged
```
#### Type parameters

<a name='EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TKey'></a>

`TKey`

<a name='EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TValue'></a>

`TValue`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ObservableDictionary<TKey,TValue>

Implements [System.Collections.Generic.IDictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[TKey](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TKey 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2')[TValue](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TValue 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IDictionary-2 'System.Collections.Generic.IDictionary`2'), [System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TKey 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TValue 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1'), [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TKey](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TKey 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TKey')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TValue](EficazFramework.Collections/ObservableDictionary_TKey,TValue_.md#EficazFramework.Collections.ObservableDictionary_TKey,TValue_.TValue 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TValue')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [System.ComponentModel.INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/System.ComponentModel.INotifyPropertyChanged 'System.ComponentModel.INotifyPropertyChanged'), [System.Collections.Specialized.INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Specialized.INotifyCollectionChanged 'System.Collections.Specialized.INotifyCollectionChanged')

| Constructors | |
| :--- | :--- |
| [ObservableDictionary()](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary().md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary()') | |
| [ObservableDictionary(int)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary(int).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary(int)') | |
| [ObservableDictionary(int, IEqualityComparer&lt;TKey&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary(int,IEqualityComparer_TKey_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary(int, System.Collections.Generic.IEqualityComparer<TKey>)') | |
| [ObservableDictionary(IDictionary&lt;TKey,TValue&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary(IDictionary_TKey,TValue_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary(System.Collections.Generic.IDictionary<TKey,TValue>)') | |
| [ObservableDictionary(IDictionary&lt;TKey,TValue&gt;, IEqualityComparer&lt;TKey&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary(IDictionary_TKey,TValue_,IEqualityComparer_TKey_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary(System.Collections.Generic.IDictionary<TKey,TValue>, System.Collections.Generic.IEqualityComparer<TKey>)') | |
| [ObservableDictionary(IEqualityComparer&lt;TKey&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ObservableDictionary(IEqualityComparer_TKey_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ObservableDictionary(System.Collections.Generic.IEqualityComparer<TKey>)') | |

| Properties | |
| :--- | :--- |
| [Count](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Count.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Count') | |
| [IsReadOnly](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/IsReadOnly.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.IsReadOnly') | |
| [Keys](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Keys.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Keys') | |
| [this[TKey]](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/this[TKey].md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.this[TKey]') | |
| [Values](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Values.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Values') | |

| Methods | |
| :--- | :--- |
| [Add(KeyValuePair&lt;TKey,TValue&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Add(KeyValuePair_TKey,TValue_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Add(System.Collections.Generic.KeyValuePair<TKey,TValue>)') | |
| [Add(TKey, TValue)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Add(TKey,TValue).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Add(TKey, TValue)') | |
| [AddOrReplace(TKey, TValue)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/AddOrReplace(TKey,TValue).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.AddOrReplace(TKey, TValue)') | |
| [Clear()](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Clear().md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Clear()') | |
| [Contains(KeyValuePair&lt;TKey,TValue&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Contains(KeyValuePair_TKey,TValue_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Contains(System.Collections.Generic.KeyValuePair<TKey,TValue>)') | |
| [ContainsKey(TKey)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ContainsKey(TKey).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ContainsKey(TKey)') | |
| [ContainsValue(TValue)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/ContainsValue(TValue).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.ContainsValue(TValue)') | |
| [CopyTo(KeyValuePair&lt;TKey,TValue&gt;[], int)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/CopyTo(KeyValuePair_TKey,TValue_[],int).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.CopyTo(System.Collections.Generic.KeyValuePair<TKey,TValue>[], int)') | |
| [GetEnumerator()](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/GetEnumerator().md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.GetEnumerator()') | |
| [IndexOf(TKey)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/IndexOf(TKey).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.IndexOf(TKey)') | |
| [Remove(KeyValuePair&lt;TKey,TValue&gt;)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Remove(KeyValuePair_TKey,TValue_).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Remove(System.Collections.Generic.KeyValuePair<TKey,TValue>)') | |
| [Remove(TKey)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/Remove(TKey).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.Remove(TKey)') | |
| [TryGetValue(TKey, TValue)](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/TryGetValue(TKey,TValue).md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.TryGetValue(TKey, TValue)') | |

| Events | |
| :--- | :--- |
| [CollectionChanged](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/CollectionChanged.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.CollectionChanged') | |
| [PropertyChanged](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/PropertyChanged.md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.PropertyChanged') | |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.IEnumerable.GetEnumerator()](EficazFramework.Collections/ObservableDictionary_TKey,TValue_/System.Collections.IEnumerable.GetEnumerator().md 'EficazFramework.Collections.ObservableDictionary<TKey,TValue>.System.Collections.IEnumerable.GetEnumerator()') | |
