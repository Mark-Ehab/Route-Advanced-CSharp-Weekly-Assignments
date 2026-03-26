using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace Assignment01;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("╔════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    Advanced C# - ASSIGNMENT WITH ANSWERS           ║");
        Console.WriteLine("║                            20 Questions                            ║");
        Console.WriteLine("║                           Assiginment (1)                          ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════════════════╝\n");

        #region Question01
        //===========================================================================================
        // Q1: What is a generic class? Why use generics?
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => A generic class is a class that uses type parameters that are replaced with actual types
               when an instance of that class is created

            => Generics are used for the following reasons:
               1) Type Safety => It provides compile-time type checking
               2) Performance => Since no Boxing or Unboxing are used like in the past when Object type 
                                 was used instead of generics to generalize the usage of classes, methods
                                 interfaces and delegates
               3) Code Reusability => It provides one implementation that works with all typs
               4) IntelliSense => It provides better IDE support and discovery
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question02
        //===========================================================================================
        // Q2: Write a generic class Container<T> with Add and Get methods.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            Answer :-

            public class Container<T>
            {
                private readonly List<T> _container = [];
                public void Add(T item) => this._container.Add(item);
                public T Get(int itemId) => this._container[itemId];
            }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question03
        //===========================================================================================
        // Q3: :What are multiple type parameters? Write Pair<TKey,TValue>.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
           => Multiple type parameters generic means that a generic class, method, interface or delegate 
              could have more than one type passed as parameters

           =>  Implementation of Pair<TKey,TValue> multi-type parameter generic class

               public class Pair<TKey, TValue>
               {
                   public TKey Key { get; set; } = default!;
                   public TValue Value { get; set; } = default!;
               
                   public Pair(TKey key , TValue value)
                   {
                       this.Key = key;
                       this.Value = value;
                   }
               
                   public void Deconstruct(out TKey key , out TValue value)
                   {
                       key = this.Key;
                       value = this.Value;
                   }
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question04
        //===========================================================================================
        // Q4: What is a generic method? Write Swap<T> method.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => A generic method is a method that declares its own generic type parameter(s) and its argument(s)
               type(s) are infered from passed argument(s) when the method is called. It's usually preferred 
               over methods overloading when the method have same number of argements and implementation but
               for multiple types otherwise method overloading is better depending on the context
            
            => Swap<T> generic method

               public static void Swap<T> (ref T value1 , ref T value2)
               {
                   T temp = value1;
                   value1 = value2;
                   value1 = temp;
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question05
        //===========================================================================================
        // Q5: Write a generic method FindMax<T> that finds maximum value
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            Answer:- 

            public T FindMax<T> (IEnumerable<T> list) where T : IComparable<T>
            {
                T max = default!;
                
                foreach(T item in list)
                {
                    if(item.CompareTo(max) > 0)
                    {
                        max = item;
                    }
                }
                
                return max;
            }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question06
        //===========================================================================================
        // Q6: What is a generic interface? Write IRepository<T>.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
           => A generic interface is a type of contracts that define generic type parameter(s) and any class
              implements that type of interfaces shall specify the actual type(s)

           => IRepository<T>
             
           public interface IRepository<T> where T : class
           {
               T? GetById(int id);
               IReadOnlyList<T> GetAll();
               void Add(T item);
               void Update(int id, T item);
               void Delete(int id);
           }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question07
        //===========================================================================================
        // Q7: What is the 'struct' constraint? Write an example.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => 'struct' constraint forces/restricts the generic type <T> to be a value type only

            => Example (Creating generic Nullable struct with struct constraint) :
              
              public struct Nullable<T> where T : struct
              {
                  public bool HasValue { get; private set; }
                  public T Value
                  {
                      get => HasValue ? field :
                          throw new InvalidOperationException("Nullable object must have a value");
                      set;
                  }
                  public Nullable()
                  {
                      this.HasValue = false;
                  }
                  public Nullable(T value)
                  {
                      this.Value = value;
                      this.HasValue = true;
                  }
              }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question08
        //===========================================================================================
        // Q8: What is the 'class' constraint? Write an example.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => 'class' constraint forces/restricts the generic type <T> to be a reference type only
            
            => Example (Creating generic Repository class with class constraint) :
               
               public interface IRepository<T> where T : class
               {
                   T? GetById(int id);
                   IReadOnlyList<T> GetAll();
                   void Add(T item);
                   void Update(int id, T item);
                   void Delete(int id);
               }
               public class GenericRepository<T> : IRepository<T> where T : class
               {
                   private readonly List<T> _items = [];
                   public void Add(T item)
                   {
                       if(item is null)
                           throw new ArgumentNullException("Passed item is null");
                       this._items.Add(item);
                   }
               
                   public void Delete(int id)
                   {
                       this._items.RemoveAt(id);
                   }
               
                   public IReadOnlyList<T> GetAll()
                   {
                       return _items;
                   }
               
                   public T? GetById(int id)
                   {
                       if (this._items[id] is null)
                           throw new ArgumentNullException("Returned item is null");
                       return this._items[id];
                   }
               
                   public void Update(int id, T item)
                   {
                       if (item is null)
                           throw new ArgumentNullException("Passed item is null");
                       this._items[id] = item;
                   }
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question09
        //===========================================================================================
        // Q9: What is the 'new()' constraint? Write an example
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => 'new()' constraint means that the generic type <T> must have a public parameterless default 
                constructor.This probably allows you to create instances of T inside the generic code

            => static generic Factory class example:
               
               public static class Factory<T> where T : new()
               {
                   public static T Create()
                   {
                       return new T();
                   }
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question10
        //===========================================================================================
        // Q10: What is the interface constraint? Write an example.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => Inerface constraint means that the generic type <T> to be passed must implement a specific 
               interface

            => Generic BubbleSort method example
               
               public static List<T> BubbleSort<T>(List<T> list) where T : IComparable<T>
               {
                    for(int i = 0; i < list.Count - 1; i++)
                    {
                       for (int j = 0; j < list.Count - 1 - i; j++)
                       {
                           if (list[j].CompareTo(list[j+1]) > 0)
                           {
                               T temp = list[j];
                               list[j] = list[j+1];
                               list[j+1] = temp;
                           }
                       }
                   }
                    return list;
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question11
        //===========================================================================================
        // Q11: What is the base class constraint? Write an example.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => 'base class' constraint forces/restricts the generic type <T> to inherit from a specific
                base class

            => Example (Creating AnimalProcessor<T> generic class that accepts a generic type that must inherit  
                        from Animal class) 
               
               public abstract class Animal
               {
                   public abstract void Eat();
               }
               
               public class Dog : Animal
               {
                   public override void Eat()
                   {
                       Console.WriteLine("Dog is eating ...");
                   }
               }
               
               public class Cat : Animal
               {
                   public override void Eat()
                   {
                       Console.WriteLine("Cat is eating ...");
                   }
               }
               
               public class AnimalProcessor<T> where T : Animal
               {
                   public void Process(T animal)
                   {
                       animal.Eat(); 
                   }
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question12
        //===========================================================================================
        // Q12: How do you apply multiple constraints? Write an example.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => You can combine multiple constraints for a single type parameter, and have different 
               constraints for different type parameters.

            => Example :

               public class EntityManager<T> where T : class, IEntity, new()
               {
                   public T CreateAndSave()
                   {
                       var entity = new T();      
                       entity.Id = Guid.NewGuid();
                       return entity;
                   }
               }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question13
        //===========================================================================================
        // Q13: What does the 'default' keyword do in generics?
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            'default' keyword returns the default value of generic type <T> to be passed by the caller/
             client when the code is used
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question14
        //===========================================================================================
        // Q14: : Write a SafeList<T> that returns default when the index is invalid.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            public class SafeList<T>
            {
                private List<T> _safeList = [];
            
                public IReadOnlyList<T> List => _safeList;
            
                public T? this[int index] 
                { 
                    get
                    {
                        if (index < 0 || index >= _safeList.Count)
                            return default;
                        return _safeList[index];
                    }
                    set
                    {
                        if (index < 0 || index >= _safeList.Count)
                            throw new ArgumentOutOfRangeException("index is out of range");
                        _safeList[index] = value!;
                    }
                }
            
                public SafeList() {}
            
                public void Add(T item)
                {
                    _safeList.Add(item);
                }
            }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question15
        //===========================================================================================
        // Q15: What is covariance? Explain the 'out' keyword.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => Covariance is a concept in C# that allows using less generic type than orignally specified
               meaning that if we have two classes one inherits from the other so a generic type of
               Derived can be used when the same generic type of Base is expected but only as data
               producer

            => 'out' keyword means that a generic type <T> can only be used in output positions (methods
                returns only)
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question16
        //===========================================================================================
        // Q16: What is contravariance? Explain the 'in' keyword.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            => Contravariance is a concept in C# that allows using more generic type than orignally 
               specified meaning that if we have two classes one inherits from the other so a generic type 
               of Base can be used when the same generic type of Derived is expected but only as data
               consumer

            => 'in' keyword means that a generic type <T> can only be used in input positions (methods
                input parameters only)
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question17
        //===========================================================================================
        // Q17: What is the difference between covariance and contravariance ?
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            Covariance (out) allows using less generic type than orignally specified but only as data
            producer [Output only (return)] while Cotravariance (in) allows using more generic type than 
            orignally specified but only as data consumer [Input only (parameter)]
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question18
        //===========================================================================================
        // Q18: How do static members work in generic types?
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            Each closed generic type has its own copy of static members meaning that List<int> and 
            List<string> are completely different classes and each have its own separate static members
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question19
        //===========================================================================================
        // Q19: How can you inherit from a generic class?
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
            There three patterns to inherit from a generic class as follows:
            1) A generic class inherits from another generic class and pass the type paremeter
               Ex:
                    public class Repository<T> {} // Base Class
                    public class CachedRepository<T> : Repository<T> { }

            2) A concrete class inherits from generic class
               Ex:
                    public class UserRepository : Repository<User> { }

            3) A multi type parameter generic class inherits from anotehr single type parameter generic 
               class and pass the type paremeter
               Ex:
                    public class KeyedRepository<TKey, TEntity> : Repository<TEntity> { }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Question20
        //===========================================================================================
        // Q20: Complete Exercise - Create a generic Cache<TKey,TValue> with Add, Get, Remove,
        //      Contains, and expiration support.
        //===========================================================================================

        /*-------------------------------------------------------------------------------------------------
           public class Cache<TKey, TValue> where TKey : notnull
           {
               private readonly Dictionary<TKey, CacheItem> _cache = new Dictionary<TKey, CacheItem>();
           
               public void Add(TKey key, TValue value, TimeSpan expirationSpan)
               {
                   if (this.Contains(key))
                       throw new InvalidOperationException("Cannot add item as passed key already exists");
                   _cache[key] = new CacheItem(value,DateTime.UtcNow.Add(expirationSpan));
               }
               public TValue? Get(TKey key)
               {
                   if (_cache[key] is null)
                       return default;
           
                   if (this.IsExpired(_cache[key]))
                   {
                       this.Remove(key);
                       return default;
                   }
           
                   return _cache[key].Value;
               }
               public bool Remove(TKey key) => _cache.Remove(key);
               public bool Contains(TKey key)
               {
                   if (this.IsExpired(_cache[key]))
                   {
                       this.Remove(key);
                       return false;
                   }
                   return _cache.ContainsKey(key); 
               }
               private bool IsExpired(CacheItem cacheItem) => cacheItem.ExpirationTime < DateTime.UtcNow;
           
               private class CacheItem
               {
                   public TValue Value { get; set; }
                   public DateTime ExpirationTime { get; set; }
                   public CacheItem(TValue value, DateTime expirationTime)
                   {
                       Value = value;
                       ExpirationTime = expirationTime;
                   }
               }
           }
        -------------------------------------------------------------------------------------------------*/
        #endregion

        #region Test Region
        /* Test Region */
        //int? x = null;
        //x = 3;
        //Console.WriteLine(x.HasValue ? x.Value : default);
        //Console.WriteLine(x.HasValue );
        //Console.WriteLine(x.Value );
        //var y = new Nullable<int>(4);
        //Console.WriteLine(y.HasValue);
        //Console.WriteLine(y.Value);

        //int? x = null;
        //x = 3;

        //foreach(int item in BubbleSort<int>([7, 5, 3, 2, 9, 4, 6]))
        //    Console.Write($"{item} ");

        //List<int> list = [];
        //list.Add(2);
        ////list[0] = 1;
        //Console.WriteLine(list[0]);

        //SafeList<int> list = new SafeList<int>();
        //list.Add(2);
        //list[0] = 1;
        //Console.WriteLine(list[0]);
        //Console.WriteLine(list[1]);

        //TimeSpan timeSpan = new TimeSpan(1,0,0,0);
        //Console.WriteLine(timeSpan);

        //Console.WriteLine(DateTime.MaxValue);
        #endregion
    }
}